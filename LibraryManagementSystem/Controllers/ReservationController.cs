using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.ViewModel.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Controllers
{
    public class ReservationController(
        IBookRepository _BookRepository,
        IGenericRepository<Member> _MemberRepsitory,
        IReservationRepository _ReservationRepository,
        UserManager<Member> _UserManager) : Controller
    {
        private readonly IBookRepository BookRepository = _BookRepository;
        private readonly IReservationRepository ReservationRepository = _ReservationRepository;
        private readonly IGenericRepository<Member> MemberRepository = _MemberRepsitory;
        private readonly UserManager<Member> UserManager = _UserManager;

        // Index view to display all reservations with applied filters and pagination.
        [Authorize(Roles = "Admin")]
        public IActionResult Index(ReservationFilterViewModel filter, int pg = 1)
        {
            const int pageSize = 8;
            if (pg < 1) pg = 1;

            // Apply filters to get the reservation based on the filter parameters.
            var reservations = FilterReservations(filter);
            var pager = new Pager(reservations.Count, pg, pageSize);
            
            // Paginate the filtered reservations.
            List<Reservation> paginatedReservations = reservations
                .Skip((pg - 1) * pageSize)
                .Take(pager.PageSize)
                .ToList();
            
            ReservationsPagerViewModel ViewModel = CreateReservationsViewModel(paginatedReservations, filter, pager);
            return View("Index", ViewModel);
        }

        // Apply filters based on user input in the ReservationsFilterViewModel.
        private List<Reservation> FilterReservations(ReservationFilterViewModel filter)
        {
            var reservations = ReservationRepository.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                reservations = reservations.Where(reservation =>
                    reservation.Id.ToString().Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (MemberRepository.GetById(reservation.MemberId).FirstName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (MemberRepository.GetById(reservation.MemberId).LastName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    BookRepository.GetBookDetailsById(reservation.BookId).Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Apply filter and sorting based on user preference
            reservations = ApplyDataFilters(reservations, filter);
            reservations = ApplySorting(reservations, filter.SortBy, filter.SortOrder);

            return [.. reservations];
        }

        // Method to apply data filters (status, Reservation, due, return dates)
        private static IQueryable<Reservation> ApplyDataFilters(IQueryable<Reservation> query, ReservationFilterViewModel filter)
        {
            if (filter.Status != null)
            {
                query = query.Where(res => res.Status == filter.Status);
            }

            if (filter.ReservationDateFrom.HasValue)
            {
                query = query.Where(res => res.ReservationDate >= filter.ReservationDateFrom.Value);
            }

            if (filter.ReservationDateTo.HasValue)
            {
                query = query.Where(res => res.ReservationDate <= filter.ReservationDateTo.Value);
            }

            if (filter.ExpirationDateFrom.HasValue)
            {
                query = query.Where(res => res.ExpiryDate >= filter.ExpirationDateFrom.Value);
            }

            if (filter.ExpirationDateTo.HasValue)
            {
                query = query.Where(res => res.ExpiryDate <= filter.ExpirationDateFrom.Value);
            }

            return query;
        }

        // Apply sorting based on the 'SortBy' and 'SortOrder' properties.
        private IQueryable<Reservation> ApplySorting(IQueryable<Reservation> query, string? sortBy, string? sortOrder)
        {
            // Check if sorting is ascending or descending (ascending if sortOrder is null or not "desc")
            var isAscending = string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() != "desc";

            query = sortBy?.ToLower() switch
            {
                "membername" => isAscending
                ? query.OrderBy(r => MemberRepository.GetById(r.MemberId).FirstName)
                        .ThenBy(r => MemberRepository.GetById(r.MemberId).LastName)
                : query.OrderByDescending(r => MemberRepository.GetById(r.MemberId).FirstName)
                        .ThenByDescending(r => MemberRepository.GetById(r.MemberId).LastName),

                "booktitle" => isAscending
                ? query.OrderBy(r => BookRepository.GetById(r.BookId).Title)
                : query.OrderByDescending(r => BookRepository.GetById(r.BookId).Title),

                "reservationdate" => isAscending
                             ? query.OrderBy(r => r.ReservationDate)
                             : query.OrderByDescending(r => r.ReservationDate),
                "expirydate" => isAscending
                             ? query.OrderBy(m => m.ExpiryDate)
                             : query.OrderByDescending(m => m.ExpiryDate),
                _ => query.OrderBy(m => m.ReservationDate) // Default sorting
            };

            return query;
        }

        // Create select list for drop-down options (membership types).
        private static List<SelectListItem> CreateSelectList(IEnumerable<Status> items, Status? selectedValue, string defaultOption)
        {
            var selectList = items
                .OrderBy(i => i)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = i == selectedValue })
                .ToList();

            // Add default option at the top.
            selectList.Insert(0, new SelectListItem { Value = "", Text = defaultOption, Selected = selectedValue == null });
            return selectList;
        }

        private ReservationsPagerViewModel CreateReservationsViewModel(IEnumerable<Reservation> reservations, ReservationFilterViewModel filter, Pager pager)
        {
            var reservationData = new List<ReservationMemberBookViewModel>();

            foreach (var item in reservations)
            {
                var book = BookRepository.GetBookDetailsById(item.BookId);
                var member = MemberRepository.GetById(item.MemberId);
                string bookName = book?.Title ?? "Unknown";
                string memberName = member == null
                    ? "Unknown"
                    : $"{member.FirstName} {member.LastName}";

                reservationData.Add(new ReservationMemberBookViewModel
                {
                    Id = item.Id,
                    ReservationDate = item.ReservationDate,
                    ExpiryDate = item.ExpiryDate,
                    Status = item.Status,
                    BookId = item.BookId,
                    BookName = bookName,
                    MemberId = memberName,
                    MemberName = item.Member.FirstName + " " + item.Member.LastName
                });
            }

            return new ReservationsPagerViewModel()
            {
                Reservations = reservationData,
                PagerSearchViewModel = new PagerSearchViewModel()
                {
                    Pager = pager,
                    SearchQuery = filter.SearchQuery ?? ""
                },
                StatusSelectList = CreateSelectList(
                    Enum.GetValues(typeof(Status))
                        .Cast<Status>(),
                    filter.Status,
                    "All"
                ),
                Filter = filter
            };
        }

        // Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Reservation? resItem = ReservationRepository.GetById(id);

            var book = BookRepository.GetBookDetailsById(resItem.BookId);
            var member = MemberRepository.GetById(resItem.MemberId);
            string bookName = book?.Title ?? "Unknown";
            string memberName = member == null
                ? "Unknown"
                : $"{member.FirstName} {member.LastName}";

            ReservationMemberBookViewModel ReservationMemberNameBookNameViewModel = new ReservationMemberBookViewModel()
            {
                Id = resItem.Id,
                ReservationDate = resItem.ReservationDate,
                ExpiryDate = resItem.ExpiryDate,
                Status = resItem.Status,
                BookId = resItem.BookId,
                BookName = bookName,
                MemberId = memberName,
                MemberName = resItem.Member.FirstName + " " + resItem.Member.LastName
            };

            if (resItem == null)
            {
                return NotFound();
            }

            return View("Delete", ReservationMemberNameBookNameViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveDelete(int id)
        {
            ReservationRepository.Delete(id);
            ReservationRepository.Save();

            TempData["SuccessMessage"] = "The reservation has been deleted successfully!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Client")]
        public ActionResult ReservedBooks(ReservationFilterViewModel filter, int pg = 1)
        {
            const int pageSize = 8;
            if (pg < 1) pg = 1;

            // Apply filters to get the user reservation based on the filter parameters.
            var reservations = FilterReservedBooks(filter);
            var pager = new Pager(reservations.Count, pg, pageSize);

            // Paginate the filtered reservations.
            List<Reservation> paginatedReservations = reservations
                .Skip((pg - 1) * pageSize)
                .Take(pager.PageSize)
                .ToList();

            ReservationsPagerViewModel ViewModel = CreateReservationsViewModel(paginatedReservations, filter, pager);
            return View("ReservedBooks", ViewModel);
        }

        private List<Reservation> FilterReservedBooks(ReservationFilterViewModel filter)
        {
            var userId = UserManager?.GetUserId(User);
            var query = ReservationRepository.GetReservationsByMemberId(userId).AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                query = query.Where(res =>
                    res.Book.Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    res.Member.FirstName.StartsWith(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    res.Member.LastName.StartsWith(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    res.Id.ToString().Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            if (filter.Status != null)
            {
                query = query.Where(res => res.Status == filter.Status);
            }

            if (filter.ReservationDateFrom.HasValue)
            {
                query = query.Where(res => res.ReservationDate >= filter.ReservationDateFrom.Value);
            }

            if (filter.ReservationDateTo.HasValue)
            {
                query = query.Where(res => res.ReservationDate <= filter.ReservationDateTo.Value);
            }

            if (filter.ExpirationDateFrom.HasValue)
            {
                query = query.Where(res => res.ExpiryDate >= filter.ExpirationDateFrom.Value);
            }

            if (filter.ExpirationDateTo.HasValue)
            {
                query = query.Where(res => res.ExpiryDate <= filter.ExpirationDateFrom.Value);
            }

            // Apply sorting
            query = ApplySorting(query, filter.SortBy, filter.SortOrder);

            return query.ToList();
        }

        // Make the user reserve a book
        public IActionResult ReserveBook(int Id)
        {
            var userId = UserManager.GetUserId(User);
            var book = BookRepository.GetById(Id);
            var member = MemberRepository.GetById(userId);

            if (book == null || member == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                BookId = Id,
                MemberId = userId,
                ReservationDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(3),
                Status = Status.Waiting
            };

            ReservationRepository.Add(reservation);
            ReservationRepository.Save();

            TempData["SuccessMessage"] = "The book has been reserved successfully!";
            return RedirectToAction("Index", "Book");
        }

        // Make user cancel a reservation
        public IActionResult CancelReservation(int id)
        {
            var reservation = ReservationRepository.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Status = Status.Cancelled;
            ReservationRepository.Update(reservation);
            ReservationRepository.Save();

            TempData["SuccessMessage"] = "The reservation has been cancelled successfully!";
            return RedirectToAction("Index");
        }
    }
}
