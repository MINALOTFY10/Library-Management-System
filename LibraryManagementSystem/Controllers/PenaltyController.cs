using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.ViewModel.Penalties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class PenaltyController(
        IBookRepository _BookRepository,
        IGenericRepository<BookCopy> _BookCopyRepository,
        IGenericRepository<Member> _MemberRepsitory,
        IPenaltyRepository _PenaltyRepository,
        UserManager<Member> _UserManager) : Controller
    {
        // Dependency injection of repositories and UserManager for accessing data and user information
        private readonly IBookRepository BookRepository = _BookRepository;
        private readonly IGenericRepository<BookCopy> BookCopyRepository = _BookCopyRepository;
        private readonly IGenericRepository<Member> MemberRepository = _MemberRepsitory;
        private readonly IPenaltyRepository PenaltyRepository = _PenaltyRepository;
        private readonly UserManager<Member> UserManager = _UserManager;

        // Displays the list of penalties with pagination and filtering
        public IActionResult Index(PenaltyFilterViewModel filter, int pg = 1)
        {
            const int pageSize = 8; // Define page size
            if (pg < 1) pg = 1;

            // Retrieve all penalties and apply filtering
            List<Penalty> PenaltyData = PenaltyRepository.GetAll();
            var penalties = FilterPenalties(filter, PenaltyData);

            // Setup pagination
            var pager = new Pager(penalties.Count, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            List<Penalty> paginatedPenalties = penalties.Skip(recSkip).Take(pager.PageSize).ToList();

            // Create a view model to pass to the view.
            var PenaltiesPagerViewModel = CreatePenaltyViewModels(paginatedPenalties, filter, pager);

            return View("Index", PenaltiesPagerViewModel);
        }

        // Filters the penalties based on the provided filter criteria
        private List<Penalty> FilterPenalties(PenaltyFilterViewModel filter, List<Penalty> penaltyData)
        {
            var query = penaltyData.AsQueryable();

            // Apply search query
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                query = query.Where(penalty =>
                    penalty.Id.ToString().Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (MemberRepository.GetById(penalty.MemberId).FirstName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (MemberRepository.GetById(penalty.MemberId).LastName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (BookRepository.GetBookDetailsById(BookCopyRepository.GetById(penalty.Id).BookId))!.Title.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Apply data filters
            query = ApplyDataFilters(query, filter);

            // Apply sorting based on user selection
            query = ApplySorting(query, filter.SortBy, filter.SortOrder);

            return [.. query];
        }

        // Method to apply data filters (Penalty, Borrow, due, return dates)
        private static IQueryable<Penalty> ApplyDataFilters(IQueryable<Penalty> query, PenaltyFilterViewModel filter)
        {
            // Apply other filters
            if (filter.PenaltyType != null)
                query = query.Where(res => res.PenaltyType == filter.PenaltyType);

            if (filter.PaidStatus != null)
                query = query.Where(res => res.PaidStatus == filter.PaidStatus);

            if (filter.BorrowDateFrom.HasValue)
                query = query.Where(res => res.BorrowDate >= filter.BorrowDateFrom.Value);

            if (filter.BorrowDateTo.HasValue)
                query = query.Where(res => res.BorrowDate <= filter.BorrowDateTo.Value);

            if (filter.DueDateFrom.HasValue)
                query = query.Where(res => res.DueDate >= filter.DueDateFrom.Value);

            if (filter.DueDateTo.HasValue)
                query = query.Where(res => res.DueDate <= filter.DueDateTo.Value);

            if (filter.ReturnDateFrom.HasValue)
                query = query.Where(res => res.ReturnDate >= filter.ReturnDateFrom.Value);

            if (filter.ReturnDateTo.HasValue)
                query = query.Where(res => res.ReturnDate <= filter.ReturnDateTo.Value);

            return query;
        }

        // Applies sorting to the penalties
        private IQueryable<Penalty> ApplySorting(IQueryable<Penalty> query, string? sortBy, string? sortOrder)
        {
            var isAscending = string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() != "desc";

            query = sortBy?.ToLower() switch
            {
                "membername" => isAscending
                    ? query.OrderBy(r => MemberRepository.GetById(r.MemberId).FirstName)
                           .ThenBy(r => MemberRepository.GetById(r.MemberId).LastName)
                    : query.OrderByDescending(r => MemberRepository.GetById(r.MemberId).FirstName)
                           .ThenByDescending(r => MemberRepository.GetById(r.MemberId).LastName),

                "booktitle" => isAscending
                    ? query.OrderBy(r => BookRepository.GetBookDetailsById(BookCopyRepository.GetById(r.BookCopyId).BookId).Title)
                    : query.OrderByDescending(r => BookRepository.GetBookDetailsById(BookCopyRepository.GetById(r.BookCopyId).BookId).Title),

                "borrowdate" => isAscending
                    ? query.OrderBy(r => r.BorrowDate)
                    : query.OrderByDescending(r => r.BorrowDate),

                "duedate" => isAscending
                    ? query.OrderBy(r => r.DueDate)
                    : query.OrderByDescending(r => r.DueDate),

                _ => query.OrderBy(r => r.DueDate) // Default sorting
            };

            return query;
        }

        // Method to create the main view model for the index view
        private PenaltiesPagerViewModel CreatePenaltyViewModels(List<Penalty> penalties, PenaltyFilterViewModel filter, Pager pager)
        {
            // Map penalties to the view model
            var penaltyData = new List<PenaltyMemberBookViewModel>();

            foreach (var item in penalties)
            {
                var book = BookRepository.GetBookDetailsById(BookCopyRepository.GetById(item.BookCopyId).BookId);
                var member = MemberRepository.GetById(item.MemberId);

                // Handle cases where book or member data might be null
                string bookName = book?.Title ?? "Unknown";
                string memberName = member == null
                    ? "Unknown"
                    : $"{member.FirstName} {member.LastName}";

                penaltyData.Add(new PenaltyMemberBookViewModel
                {
                    Id = item.Id,
                    BorrowDate = item.BorrowDate,
                    DueDate = item.DueDate,
                    ReturnDate = item.ReturnDate,
                    PenaltyType = item.PenaltyType,
                    PenaltyAmount = item.PenaltyAmount,
                    PaidStatus = item.PaidStatus,
                    BookId = BookCopyRepository.GetById(item.BookCopyId).BookId,
                    BookName = bookName,
                    MemberId = item.MemberId,
                    MemberName = memberName
                });
            }

            // Pass data to the view
            return new PenaltiesPagerViewModel()
            {
                Penalties = penaltyData,
                PagerSearchViewModel = new PagerSearchViewModel()
                {
                    Pager = pager,
                    SearchQuery = filter.SearchQuery ?? ""
                },
                PenaltyTypesSelectList = CreateSelectList(
                    Enum.GetValues(typeof(PenaltyType))
                        .Cast<PenaltyType>(),
                    filter.PenaltyType,
                    "All"                
                ),
                Filter = filter
            };
        }

        // Create select list for drop-down options (membership types).
        private static List<SelectListItem> CreateSelectList(IEnumerable<PenaltyType> items, PenaltyType? selectedValue, string defaultOption)
        {
            var selectList = items
                .OrderBy(i => i)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = i == selectedValue })
                .ToList();

            // Add default option at the top.
            selectList.Insert(0, new SelectListItem { Value = "", Text = defaultOption, Selected = selectedValue == null });
            return selectList;
        }

        public IActionResult MemberPenalties(PenaltyFilterViewModel filter, int pg = 1)
        {
            const int pageSize = 8; // Define page size
            if (pg < 1) pg = 1;

            // Retrieve penalties of specific user and apply filtering
            var userId = UserManager.GetUserId(User);
            var PenaltyData = PenaltyRepository.GetPenaltiesByMemberId(userId);
            var penalties = FilterPenalties(filter, PenaltyData);

            // Setup pagination
            var pager = new Pager(penalties.Count, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            List<Penalty> paginatedPenalties = penalties.Skip(recSkip).Take(pager.PageSize).ToList();

            // Create a view model to pass to the view.
            var PenaltiesPagerViewModel = CreatePenaltyViewModels(paginatedPenalties, filter, pager);

            return View("MemberPenalties", PenaltiesPagerViewModel);
        }
    }
}
