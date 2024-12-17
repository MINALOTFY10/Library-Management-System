using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.ViewModel.BorrowsCopies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowsCopiesController(
        IBookRepository bookRepository,
        IBookCopyRepository bookCopyRepository,
        IGenericRepository<Member> memberRepository,
        IBorrowsCopyRepository borrowsCopyRepository,
        IGenericRepository<Genre> genreRepository,
        UserManager<Member> userManager,
        IPenaltyRepository penaltyRepository) : Controller
    {
        // Private fields for dependency injection of repositories and services
        private readonly IBorrowsCopyRepository _borrowsCopyRepository = borrowsCopyRepository;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
        private readonly IGenericRepository<Member> _memberRepository = memberRepository;
        private readonly IGenericRepository<Genre> _genreRepository = genreRepository;
        private readonly UserManager<Member> _userManager = userManager;
        private readonly IPenaltyRepository _penaltyRepository = penaltyRepository;

        // Action method to display a paginated and filtered list of borrowed copies
        public IActionResult Index(BorrowsCopiesFilterViewModel filter, int pg = 1)
        {
            const int pageSize = 8; // Enforce a fixed page size to standardize pagination behavior across views.
            pg = Math.Max(pg, 1);

            // Apply filters and sorting to the list of borrowed copies
            var borrows = ApplyFilters(filter);
            var pager = new Pager(borrows.Count, pg, pageSize); // Create a pager object for pagination

            // Get the paginated list of borrowed copies
            var paginatedBorrows = borrows
                .Skip((pg - 1) * pageSize)
                .Take(pager.PageSize)
                .ToList();

            // Prepare the view model for the index view
            var BorrowsCopiesViewModel = CreateBorrowsCopyViewModels(paginatedBorrows, filter, pager);

            return View("Index", BorrowsCopiesViewModel);
        }

        // Method to apply filters to the borrowed copies list based on the filter view model
        private List<BorrowsCopy> ApplyFilters(BorrowsCopiesFilterViewModel filter)
        {
            var query = _borrowsCopyRepository.GetAll().AsQueryable(); // Get all borrowed copies

            // Filter by search query if provided
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                query = query.Where(borrow =>
                    borrow.BookCopyId.ToString().Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (_memberRepository.GetById(borrow.MemberId).FirstName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (_memberRepository.GetById(borrow.MemberId).LastName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    _bookCopyRepository.GetBookByBookCopyId(borrow.BookCopyId).Book.Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase));
            }

            // Apply data filters
            query = ApplyDataFilters(query, filter);

            // Apply sorting based on user selection
            query = ApplySorting(query, filter.SortBy, filter.SortOrder);

            return [.. query];
        }

        // Method to apply data filters (status, borrow, due, return dates)
        private static IQueryable<BorrowsCopy> ApplyDataFilters(IQueryable<BorrowsCopy> query, BorrowsCopiesFilterViewModel filter)
        {
            if (filter.Status != null)
                query = query.Where(bc => bc.Status == filter.Status);

            if (filter.BorrowDateFrom.HasValue)
                query = query.Where(bc => bc.BorrowDate >= filter.BorrowDateFrom.Value);

            if (filter.BorrowDateTo.HasValue)
                query = query.Where(bc => bc.BorrowDate <= filter.BorrowDateTo.Value);

            if (filter.DueDateFrom.HasValue)
                query = query.Where(bc => bc.DueDate >= filter.DueDateFrom.Value);

            if (filter.DueDateTo.HasValue)
                query = query.Where(bc => bc.DueDate <= filter.DueDateTo.Value);

            if (filter.ReturnDateFrom.HasValue)
                query = query.Where(bc => bc.ReturnDate >= filter.ReturnDateFrom.Value);

            if (filter.ReturnDateTo.HasValue)
                query = query.Where(bc => bc.ReturnDate <= filter.ReturnDateTo.Value);

            return query;
        }

        // Method to apply sorting to the borrowed copies list
        private IQueryable<BorrowsCopy> ApplySorting(IQueryable<BorrowsCopy> query, string? sortBy, string? sortOrder)
        {
            bool isAscending = string.IsNullOrEmpty(sortOrder) || !sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase); // Default to ascending order

            return sortBy?.ToLower() switch
            {
                "membername" => isAscending
                    ? query.OrderBy(bc => _memberRepository.GetById(bc.MemberId).FirstName)
                            .ThenBy(bc => _memberRepository.GetById(bc.MemberId).LastName)
                    : query.OrderByDescending(bc => _memberRepository.GetById(bc.MemberId).FirstName)
                            .ThenByDescending(bc => _memberRepository.GetById(bc.MemberId).LastName),

                "duedate" => isAscending
                    ? query.OrderBy(bc => bc.DueDate)
                    : query.OrderByDescending(bc => bc.DueDate),

                "returndate" => isAscending
                    ? query.OrderBy(bc => bc.ReturnDate)
                    : query.OrderByDescending(bc => bc.ReturnDate),

                "borrowdate" => isAscending
                    ? query.OrderBy(bc => bc.BorrowDate)
                    : query.OrderByDescending(bc => bc.BorrowDate),

                _ => query.OrderBy(bc => bc.BorrowDate), // Default sorting by borrow date
            };
        }

        // Method to get a list of statuses for the dropdown filter
        private static List<SelectListItem> GetStatusSelectList(BookStatus? selectedStatus)
        {
            return Enum.GetValues<BookStatus>()
                .Select(status => new SelectListItem
                {
                    Value = status.ToString(),
                    Text = status.ToString(),
                    Selected = status == selectedStatus
                })
                .Prepend(new SelectListItem
                {
                    Value = "All",
                    Text = "All",
                    Selected = selectedStatus == BookStatus.None
                })
                .ToList();
        }

        // Method to create a list of view models for displaying borrowed copies
        private List<BorrowsCopyMemberBookViewModel> GetBorrowsCopyViewModels(List<BorrowsCopy> borrows)
        {
            return borrows.Select(item =>
            {
                var book = _bookCopyRepository.GetBookByBookCopyId(item.BookCopyId).Book;
                var member = _memberRepository.GetById(item.MemberId);

                return new BorrowsCopyMemberBookViewModel
                {
                    BorrowDate = item.BorrowDate,
                    DueDate = item.DueDate,
                    ReturnDate = item.ReturnDate,
                    Status = item.Status,
                    BookCopyId = item.BookCopyId,
                    BookName = book?.Title ?? "Unknown",
                    BookId = book?.Id ?? 0,
                    MemberId = item.MemberId,
                    MemberName = member == null ? "Unknown" : $"{member.FirstName} {member.LastName}"
                };
            }).ToList();
        }

        // Method to create the main view model for the index view
        private BorrowsCopiesPagerViewModel CreateBorrowsCopyViewModels(List<BorrowsCopy> borrows, BorrowsCopiesFilterViewModel filter, Pager pager)
        {
            var statusTypes = GetStatusSelectList(filter.Status); // Get the status dropdown options
            var borrowsData = GetBorrowsCopyViewModels(borrows); // Get the list of borrowed copies view models

            return new BorrowsCopiesPagerViewModel
            {
                BorrowsCopies = borrowsData,
                PagerSearchViewModel = new PagerSearchViewModel
                {
                    Pager = pager,
                    SearchQuery = filter.SearchQuery ?? ""
                },
                StatusSelectList = statusTypes,
                Filter = filter
            };
        }

        [Authorize(Roles = "Client")]
        public ActionResult UserBorrowedBooks(BookFilterViewModel filter, int pageNumber = 1)
        {
            const int PageSize = 8; // Enforce a fixed page size to standardize pagination behavior across views.
            pageNumber = Math.Max(pageNumber, 1);

            // Retrieve filtered list of borrowed books based on user input.
            var borrowedBooks = FilterBorrowedBooks(filter); 
            var pager = new Pager(borrowedBooks.Count, pageNumber, PageSize);

            var paginatedBooks = borrowedBooks
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList(); // Paginate the books to improve performance by only fetching the necessary subset.

            BorrowedBookPagerViewModel viewModel = CreateBorrowedBooksViewModel(paginatedBooks, filter, pager);

            return View("UserBorrowedBooks", viewModel);
        }

        private List<BorrowsCopy> FilterBorrowedBooks(BookFilterViewModel filter)
        {
            var userId = _userManager?.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return []; // Return an empty list if the user ID is invalid to prevent further processing.
            }

            // Fetch borrow records specific to the authenticated user.
            var query = _borrowsCopyRepository.GetBorrowRecordsByMemberId(userId).AsQueryable();

            return ApplyBookSorting(ApplyDataFilters(query, filter), filter.SortBy, filter.SortOrder).ToList();
        }

        private static IQueryable<BorrowsCopy> ApplyDataFilters(IQueryable<BorrowsCopy> query, BookFilterViewModel filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                query = query.Where(bc =>
                    bc.BookCopy.Book.Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    bc.BookCopy.Book.Author.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase));
            }

            if (filter.GenreId > 0)
                query = query.Where(bc => bc.BookCopy.Book.GenreId == filter.GenreId);

            if (filter.BorrowedFrom.HasValue)
                query = query.Where(bc => bc.BorrowDate >= filter.BorrowedFrom.Value);

            if (filter.BorrowedTo.HasValue)
                query = query.Where(bc => bc.BorrowDate <= filter.BorrowedTo.Value);

            if (filter.ReturnedFrom.HasValue)
                query = query.Where(bc => bc.ReturnDate >= filter.ReturnedFrom.Value);

            if (filter.ReturnedTo.HasValue)
                query = query.Where(bc => bc.ReturnDate <= filter.ReturnedTo.Value);

            if (filter.DueFrom.HasValue)
                query = query.Where(bc => bc.DueDate >= filter.DueFrom.Value);

            if (filter.DueTo.HasValue)
                query = query.Where(bc => bc.DueDate <= filter.DueTo.Value);

            if (filter.IsReturned.HasValue)
            {
                query = filter.IsReturned.Value
                    ? query.Where(bc => bc.ReturnDate != null)
                    : query.Where(bc => bc.ReturnDate == null);
            }

            return query;
        }
       
        private static IQueryable<BorrowsCopy> ApplyBookSorting(IQueryable<BorrowsCopy> query, string? sortBy, string? sortOrder)
        {
            var isAscending = !string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase);

            return sortBy?.ToLower() switch
            {
                "title" => isAscending ? query.OrderBy(bc => bc.BookCopy.Book.Title) : query.OrderByDescending(bc => bc.BookCopy.Book.Title),
                "author" => isAscending ? query.OrderBy(bc => bc.BookCopy.Book.Author) : query.OrderByDescending(bc => bc.BookCopy.Book.Author),
                "borrowdate" => isAscending ? query.OrderBy(bc => bc.BorrowDate) : query.OrderByDescending(bc => bc.BorrowDate),
                "returndate" => isAscending ? query.OrderBy(bc => bc.ReturnDate) : query.OrderByDescending(bc => bc.ReturnDate),
                "duedate" => isAscending ? query.OrderBy(bc => bc.DueDate) : query.OrderByDescending(bc => bc.DueDate),
                _ => query.OrderBy(bc => bc.BookCopy.Book.Title)
            };
        }

        private BorrowedBookPagerViewModel CreateBorrowedBooksViewModel(IEnumerable<BorrowsCopy> books, BookFilterViewModel filter, Pager pager)
        {
            var borrowedBookViewModels = books.Select(book => new BorrowedBookViewModel
            {
                Title = book.BookCopy.Book.Title,
                Author = book.BookCopy.Book.Author,
                Id = book.BookCopy.Book.Id,
                Genre = _genreRepository.GetById(book.BookCopy.Book.GenreId), // Fetch genre details for better display.
                BorrowedDate = book.BorrowDate,
                ReturnedDate = book.ReturnDate,
                DueDate = book.DueDate
            }).ToList();

            return new BorrowedBookPagerViewModel
            {
                Books = borrowedBookViewModels, // Provide a paginated list of books for the view.
                PagerSearchViewModel = new PagerSearchViewModel
                {
                    Pager = pager, // Attach pager details to support navigation between pages.
                    SearchQuery = filter.SearchQuery ?? string.Empty 
                },
                GenreId = filter.GenreId,
                Genres = _genreRepository.GetAll(), // Fetch all genres to populate filtering options in the view.
                Filter = filter // Pass the original filter back to maintain user input.
            };
        }

        // Create a Borrowing Proccess
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            BorrowsCopiesViewModel borrowsCopiesViewModel = new();

            borrowsCopiesViewModel.members = _memberRepository.GetAll();

            var books = _bookRepository.GetAll();
            List<Book> avialableBooks = [];

            foreach (var book in books)
            {
                bool avialable = false;
                List<BookCopy> copybooks = _bookCopyRepository.GetBookCopiesByBookId(book.Id);

                foreach (var copy in copybooks)
                {
                    if (copy.IsAvailable)
                    {
                        avialable = true;
                    }
                }
                if (avialable)
                {
                    avialableBooks.Add(book);
                }
            }

            borrowsCopiesViewModel.books = avialableBooks;

            return View("Add", borrowsCopiesViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SaveAdd(BorrowsCopiesViewModel borrowsCopiesViewModel)
        {
            var memberId = borrowsCopiesViewModel.MemberId;

            var availableBooks = GetAvailableBooks();

            if (borrowsCopiesViewModel.MemberId != null && borrowsCopiesViewModel.BookIds != null)
            {

                foreach (var bookId in borrowsCopiesViewModel.BookIds)
                {
                    var historyBc = _borrowsCopyRepository.GetByIds(memberId, bookId);
                    if (historyBc != null)
                    {
                        var bookName = _bookRepository.GetById(bookId)?.Title ?? "Unknown";
                        TempData["FailedMessage"] = $"The Borrowing has been made before. Remove {bookName}";

                        PrepareViewModel(borrowsCopiesViewModel);
                        return View("Add", borrowsCopiesViewModel);
                    }

                    var availableCopy = _bookCopyRepository.GetBookCopiesByBookId(bookId).FirstOrDefault(bc => bc.IsAvailable);
                    if (availableCopy == null)
                    {
                        TempData["FailedMessage"] = $"No available copies for the book with ID {bookId}";
                        PrepareViewModel(borrowsCopiesViewModel);
                        return View("Add", borrowsCopiesViewModel);
                    }

                    // Create a new borrow record
                    var borrowCopy = new BorrowsCopy
                    {
                        MemberId = memberId,
                        BookCopyId = availableCopy.Id,
                        BorrowDate = DateTime.Today,
                        DueDate = DateTime.Today.AddDays(14),
                        ReturnDate = null,
                        Status = BookStatus.Borrowed
                    };

                    _borrowsCopyRepository.Add(borrowCopy);

                    // Update book copy and book details
                    availableCopy.IsAvailable = false;
                    _bookCopyRepository.Update(availableCopy);

                    var book = _bookRepository.GetById(bookId);
                    if (book != null)
                    {
                        book.TotalBorrowCount++;
                        _bookRepository.Update(book);
                    }

                    // Update member details
                    var member = _memberRepository.GetById(memberId);
                    if (member != null)
                    {
                        member.TotalBorrowedBooks++;
                        _memberRepository.Update(member);
                    }
                }

                // Save changes in batch
                _borrowsCopyRepository.Save();
                _bookCopyRepository.Save();
                _bookRepository.Save();
                _memberRepository.Save();

                TempData["SuccessMessage"] = "The Borrowing has been made successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                if (borrowsCopiesViewModel.MemberId == null)
                {
                    ModelState.AddModelError("MemberId", "Please select a Member.");
                }
                if (borrowsCopiesViewModel.BookIds == null)
                {
                    ModelState.AddModelError("BookIds", "Please select a Book.");
                }
            }
            PrepareViewModel(borrowsCopiesViewModel);
            return View("Add", borrowsCopiesViewModel);
        }

        private void PrepareViewModel(BorrowsCopiesViewModel viewModel)
        {
            viewModel.members = _memberRepository.GetAll();
            viewModel.books = GetAvailableBooks();
        }

        private List<Book> GetAvailableBooks()
        {
            return _bookRepository.GetAll()
                .Where(book => _bookCopyRepository.GetBookCopiesByBookId(book.Id).Any(copy => copy.IsAvailable))
                .ToList();
        }


        // Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string memberid, int bookid)
        {
            BorrowsCopy? bcItem = _borrowsCopyRepository.GetByIds(memberid, bookid);

            var book = _bookCopyRepository.GetBookByBookCopyId(bcItem.BookCopyId).Book;
            if (book == null)
            {
                return View("NotFound");
            }

            var member = _memberRepository.GetById(bcItem.MemberId);
            string bookName = book?.Title ?? "Unknown";
            _ = member == null
                ? "Unknown"
                : $"{member.FirstName} {member.LastName}";

            BorrowsCopyMemberBookViewModel BorrowsCopyMemberBookViewModel = new BorrowsCopyMemberBookViewModel()
            {
                BorrowDate = bcItem.BorrowDate,
                DueDate = bcItem.DueDate,
                ReturnDate = bcItem.ReturnDate,
                Status = bcItem.Status,
                BookCopyId = bcItem.BookCopyId,
                BookName = bookName,
                BookId = book.Id,
                MemberId = bcItem.MemberId,
                MemberName = bcItem.Member.FirstName + " " + bcItem.Member.LastName
            };

            if (bcItem == null)
            {
                return NotFound();
            }

            return View("Delete", BorrowsCopyMemberBookViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveDelete(string memberid, int bookid)
        {
            BorrowsCopy borrowsCopy = _borrowsCopyRepository.GetByIds(memberid, bookid);
            BookCopy bookCopy = _bookCopyRepository.GetById(borrowsCopy.BookCopyId);

            bookCopy.IsAvailable = true;
            _bookCopyRepository.Update(bookCopy);
            _bookCopyRepository.Save();

            _borrowsCopyRepository.Delete(memberid, bookid);
            _borrowsCopyRepository.Save();

            TempData["SuccessMessage"] = "The borrowing has been deleted successfully!";
            return RedirectToAction("Index");
        }

        public ActionResult ReturnBook(string MemberId, int BookId, int BookCopyId)
        {
            BookCopy bookCopy = _bookCopyRepository.GetById(BookCopyId);
            bookCopy.IsAvailable = true;

            _bookCopyRepository.Update(bookCopy);
            _bookCopyRepository.Save();

            BorrowsCopy borrowsCopy = _borrowsCopyRepository.GetByIds(MemberId, BookId);
            borrowsCopy.Status = BookStatus.Returned;
            borrowsCopy.ReturnDate = DateTime.Today;

            _borrowsCopyRepository.Update(borrowsCopy);
            _borrowsCopyRepository.Save();

            // Add Penalty if the book is returned late
            if (DateTime.Today > borrowsCopy.DueDate)
            {
                // Calculate the number of days the book is late
                int daysLate = (DateTime.Today - borrowsCopy.DueDate).Days;
                
                // Calculate the penalty
                double penAmount = daysLate * 0.5;

                Penalty penalty = new()
                {
                    MemberId = MemberId,
                    PenaltyAmount = penAmount,
                    ReturnDate = DateTime.Today,
                    DueDate = borrowsCopy.DueDate,
                    BookCopyId = BookCopyId,
                    PaidStatus = false,
                };

                _penaltyRepository.Add(penalty);
                _penaltyRepository.Save();
            }
            TempData["SuccessMessage"] = "The Book has been returned successfully!";

            return Redirect(Request.Headers.Referer.ToString());
        }

    }
}
