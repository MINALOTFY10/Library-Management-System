using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Controllers
{
    // Controller to manage BOOK-related actions in the library system.
    public class BookController(
        IBookRepository bookRepository,
        IGenericRepository<Genre> genericRepository,
        IGenericRepository<BookCopy> bookCopyRepository) : Controller
    {
        // Injected dependencies for book repository, genre repository, and book copy repository.
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IGenericRepository<Genre> _genreRepository = genericRepository;
        private readonly IGenericRepository<BookCopy> _bookCopyRepository = bookCopyRepository;

        // Index view to display books with applied filters and pagination.
        [Authorize(Roles = "Admin,Client")]
        public IActionResult Index(BookFilterViewModel filter, int pg = 1)
        {
            const int PageSize = 8;
            pg = Math.Max(pg, 1); 

            // Apply filters to get the books based on the filter parameters.
            var books = ApplyBooksFilters(filter);
            var pager = new Pager(books.Count, pg, PageSize);

            // Paginate the filtered books.
            var paginatedBooks = books
                .Skip((pg - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Create a view model to pass to the view.
            var booksViewModel = CreateBooksViewModel(paginatedBooks, filter, pager);

            return View("Index", booksViewModel);
        }

        // Apply filters based on user input in the BookFilterViewModel.
        public List<Book> ApplyBooksFilters(BookFilterViewModel filter)
        {
            var books = GetBooks().AsQueryable();

            // Apply search filter if provided.
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                books = books.Where(b =>
                    b.Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase));
            }

            // Apply filter and sorting based on user preference
            books = ApplyDataFilters(books, filter);
            books = ApplySorting(books, filter.SortBy, filter.SortOrder);

            return [.. books]; // Convert to a list before returning.
        }

        private IQueryable<Book> ApplyDataFilters(IQueryable<Book> books, BookFilterViewModel filter)
        {
            // Apply genre filter if provided.
            if (filter.GenreId > 0)
                books = books.Where(b => b.GenreId == filter.GenreId);

            // Apply language filter if provided.
            if (!string.IsNullOrEmpty(filter.Language))
                books = books.Where(b => b.Language == filter.Language);

            // Apply publisher filter if provided.
            if (!string.IsNullOrEmpty(filter.Publisher))
                books = books.Where(b => b.Publisher == filter.Publisher);

            // Apply date range filters if provided.
            if (filter.PublishedFrom.HasValue)
                books = books.Where(b => b.PublishedDate >= filter.PublishedFrom.Value);

            if (filter.PublishedTo.HasValue)
                books = books.Where(b => b.PublishedDate <= filter.PublishedTo.Value);

            // Apply availability filter if provided.
            if (filter.IsAvailable.HasValue)
                books = FilterByAvailability(books, filter.IsAvailable.Value);

            return books;
        }

        // Filter books based on availability of book copies.
        private IQueryable<Book> FilterByAvailability(IQueryable<Book> books, bool isAvailable)
        {
            var bookCopies = _bookCopyRepository.GetAll();
            var availableBookIds = bookCopies
                .GroupBy(c => c.BookId)
                .Where(g => isAvailable
                    ? g.Any(c => c.IsAvailable)
                    : g.All(c => !c.IsAvailable))
                .Select(g => g.Key);

            return books.Where(b => availableBookIds.Contains(b.Id));
        }

        // Apply sorting based on the 'SortBy' and 'SortOrder' properties.
        private static IQueryable<Book> ApplySorting(IQueryable<Book> books, string? sortBy, string? sortOrder)
        {
            bool isAscending = sortOrder?.ToLower() != "desc"; // Ascending by default.
            return sortBy?.ToLower() switch
            {
                "title" => isAscending ? books.OrderBy(b => b.Title) : books.OrderByDescending(b => b.Title),
                "author" => isAscending ? books.OrderBy(b => b.Author) : books.OrderByDescending(b => b.Author),
                _ => books.OrderBy(b => b.Title) // Default sorting by title.
            };
        }

        // Create view model for displaying the list of books with filtering and pagination.
        private BooksPagerViewModel CreateBooksViewModel(IEnumerable<Book> books, BookFilterViewModel filter, Pager pager)
        {
            // Create select lists for languages and publishers.
            var languages = CreateSelectList(
                GetBooks().Select(b => b.Language).Distinct(),
                filter.Language,
                "All Languages");

            var publishers = CreateSelectList(
                GetBooks().Select(b => b.Publisher).Distinct(),
                filter.Publisher,
                "All Publishers");

            return new BooksPagerViewModel
            {
                books = books.ToList(),
                PagerSearchViewModel = new PagerSearchViewModel { Pager = pager, SearchQuery = filter.SearchQuery ?? ""},
                GenreId = filter.GenreId,
                Genres = _genreRepository.GetAll(),
                IsBookAvailable = books.Select(GetAvailabilityForBook).ToList(),
                LanguageSelectList = languages,
                PublisherSelectList = publishers,
                Filter = filter
            };
        }

        // Create select list for drop-down options (languages, publishers).
        public List<SelectListItem> CreateSelectList(IEnumerable<string> items, string? selectedValue, string defaultOption)
        {
            var selectList = items
                .OrderBy(i => i)
                .Select(i => new SelectListItem { Value = i, Text = i, Selected = i == selectedValue })
                .ToList();

            selectList.Insert(0, new SelectListItem { Value = "", Text = defaultOption, Selected = string.IsNullOrEmpty(selectedValue) });

            return selectList;
        }

        // Determine whether a book has available copies.
        private bool GetAvailabilityForBook(Book book)
        {
            return book != null && _bookCopyRepository.GetAll().Any(copy => copy.BookId == book.Id && copy.IsAvailable);
        }

        // Show details for a specific book.
        [Authorize(Roles = "Admin, Client")]
        public IActionResult ShowDetails(int id)
        {
            Book? book = _bookRepository.GetBookDetailsById(id);

            var viewModel = (book, IsAvailable: GetAvailabilityForBook(book));

            return book != null ? View("ShowDetails", viewModel) : View("NotFound");
        }

        // Add a new book (Admin only).
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View("Add", new BookGenresViewModel { Genres = _genreRepository.GetAll() });
        }

        // Save the newly added book (Admin only).
        [Authorize(Roles = "Admin")]
        public IActionResult SaveAdd(BookGenresViewModel bookGenresViewModel)
        {
            if (ModelState.IsValid)
            {
                if (bookGenresViewModel.GenreId != -1)
                {
                    Book book = new()
                    {
                        Title = bookGenresViewModel.Title,
                        Author = bookGenresViewModel.Author,
                        ISBN = bookGenresViewModel.ISBN,
                        Publisher = bookGenresViewModel.Publisher,
                        PublishedDate = bookGenresViewModel.PublishedDate,
                        Language = bookGenresViewModel.Language,
                        AddedDate = bookGenresViewModel.AddedDate,
                        TotalBorrowCount = bookGenresViewModel.TotalBorrowCount,
                        GenreId = bookGenresViewModel.GenreId
                    };

                    _bookRepository.Add(book);
                    _bookRepository.Save();

                    TempData["SuccessMessage"] = "The book has been added successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("GenreId", "Genre is required");
                }
            }

            bookGenresViewModel.Genres = _genreRepository.GetAll();
            return View("Add", bookGenresViewModel);
        }

        // Edit an existing book (Admin only).
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Book? book = _bookRepository.GetById(id);

            if (book != null)
            {
                BookGenresViewModel bookGenresViewModel = new BookGenresViewModel
                {
                    Id = id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    Publisher = book.Publisher,
                    PublishedDate = book.PublishedDate,
                    Language = book.Language,
                    AddedDate = book.AddedDate,
                    TotalBorrowCount = book.TotalBorrowCount,
                    GenreId = book.GenreId
                };

                bookGenresViewModel.Genres = _genreRepository.GetAll();

                return View("Edit", bookGenresViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        // Save the edited book (Admin only).
        [Authorize(Roles = "Admin")]
        public ActionResult SaveEdit(BookGenresViewModel bookGenresViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                Book bookDB = _bookRepository.GetById(id);

                if (bookDB != null)
                {
                    bookDB.Title = bookGenresViewModel.Title;
                    bookDB.Author = bookGenresViewModel.Author;
                    bookDB.ISBN = bookGenresViewModel.ISBN;
                    bookDB.Publisher = bookGenresViewModel.Publisher;
                    bookDB.PublishedDate = bookGenresViewModel.PublishedDate;
                    bookDB.Language = bookGenresViewModel.Language;
                    bookDB.AddedDate = bookGenresViewModel.AddedDate;
                    bookDB.TotalBorrowCount = bookGenresViewModel.TotalBorrowCount;
                    bookDB.GenreId = bookGenresViewModel.GenreId;

                    _bookRepository.Update(bookDB);
                    _bookRepository.Save();

                    TempData["SuccessMessage"] = "The book has been updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

            bookGenresViewModel.Genres = _genreRepository.GetAll();
            return View("Edit", bookGenresViewModel);
        }

        // Delete a book (Admin only).
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Book? book = _bookRepository.GetById(id);

            if (book != null)
            {
                _bookRepository.Delete(id);
                _bookRepository.Save();

                TempData["SuccessMessage"] = "The book has been deleted successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        // Get all books from the repository.
        private List<Book> GetBooks()
        {
            return _bookRepository.GetAll().ToList();
        }
    }
}
