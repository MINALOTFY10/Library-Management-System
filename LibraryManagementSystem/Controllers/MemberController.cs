using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.ViewModel.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Controllers
{
    // Controller to manage MEMBER-related actions in the library system.
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        // Injected dependencies for member repository, BorrowsCopy repository, and user repository.
        private readonly IGenericRepository<Member> memberRepsitory;
        private readonly IBorrowsCopyRepository borrowsCopyRepository;
        private readonly UserManager<Member> userManager;

        // Constructor to initialize the repositories.
        public MemberController(
            IGenericRepository<Member> memberRepsitory,
            IBorrowsCopyRepository borrowsCopyRepository,
            UserManager<Member> userManager)
        {
            this.memberRepsitory = memberRepsitory;
            this.borrowsCopyRepository = borrowsCopyRepository;
            this.userManager = userManager;
        }

        // Index view to display members with applied filters and pagination.
        public IActionResult Index(MemberFilterViewModel filter, int pg = 1)
        {
            const int PageSize = 8;
            pg = Math.Max(pg, 1); // Ensuring that page number is at least 1.

            // Apply filters to get the books based on the filter parameters.
            var members = ApplyFilters(filter);
            var pager = new Pager(members.Count, pg, PageSize);

            // Paginate the filtered members.
            List<Member> paginatedMembers = members
                .Skip((pg - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Create a view model to pass to the view.
            var membersViewModel = CreateMembersViewModel(paginatedMembers, filter, pager);

            return View("Index", membersViewModel);
        }

        // Apply filters based on user input in the MemberFilterViewModel.
        private List<Member> ApplyFilters(MemberFilterViewModel filter)
        {
            var books = memberRepsitory.GetAll().AsQueryable();

            // Apply search filter if provided.
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                books = books.Where(m =>
                    (m.FirstName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (m.LastName ?? "").Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    m.Id.Contains(filter.SearchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Apply Membership Type filter if provided.
            if (filter.MembershipType.HasValue)
                books = books.Where(m => m.MembershipType == filter.MembershipType);

            // Apply Activity filter if provided
            if (filter.IsActive.HasValue)
                books = books.Where(m => m.IsActive == filter.IsActive);

            // Apply Membership date range filters if provided.
            if (filter.MembershipFrom.HasValue)
                books = books.Where(m => m.DateOfMembership >= filter.MembershipFrom.Value);

            if (filter.MembershipTo.HasValue)
                books = books.Where(m => m.DateOfMembership <= filter.MembershipTo.Value);

            // Apply Expiration date range filters if provided.
            if (filter.ExpirationFrom.HasValue)
                books = books.Where(m => m.DateOfMembership >= filter.ExpirationFrom.Value);

            if (filter.ExpirationTo.HasValue)
                books = books.Where(m => m.DateOfMembership <= filter.ExpirationTo.Value);

            // Apply sorting based on admin preference.
            books = ApplySorting(books, filter.SortBy, filter.SortOrder);

            return books.ToList(); // Return filtered and sorted list of members.
        }

        // Apply sorting based on the 'SortBy' and 'SortOrder' properties.
        private static IQueryable<Member> ApplySorting(IQueryable<Member> query, string? sortBy, string? sortOrder)
        {
            var isAscending = string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() != "desc";
            return sortBy?.ToLower() switch
            {
                "name" => isAscending
                             ? query.OrderBy(m => m.FirstName).ThenBy(m => m.LastName)
                             : query.OrderByDescending(m => m.FirstName).ThenByDescending(m => m.LastName),
                "totalborrowedbooks" => isAscending
                             ? query.OrderBy(m => m.TotalBorrowedBooks)
                             : query.OrderByDescending(m => m.TotalBorrowedBooks),
                "joiningdate" => isAscending
                             ? query.OrderBy(m => m.DateOfMembership)
                             : query.OrderByDescending(m => m.DateOfMembership),
                _ => query.OrderBy(m => m.FirstName) // Default sorting by name.
            };
        }

        // Fetch user data for all members and transform it into view models.
        public List<UserRoleViewModel> FetchUserData(IEnumerable<Member> members)
        {
            // Fetch roles for all users in parallel
            var userRoles = members.Select(user => new
            {
                User = user,
                Role = (userManager.GetRolesAsync(user).Result.FirstOrDefault())
            });

            // Transform user data into view models
            return userRoles.Select(ur => new UserRoleViewModel
            {
                Id = ur.User.Id,
                Email = ur.User.Email,
                Role = ur.Role ?? "Client",
                FirstName = ur.User.FirstName ?? "Unknown",
                LastName = ur.User.LastName,
                MembershipType = ur.User.MembershipType,
                DateOfMembership = ur.User.DateOfMembership,
                ExpirationDate = ur.User.ExpirationDate,
                IsActive = ur.User.IsActive,
                MaxBorrowLimit = (int)ur.User.MaxBorrowLimit,
                TotalBorrowedBooks = (int)ur.User.TotalBorrowedBooks,
                PhoneNumber = ur.User.PhoneNumber
            }).ToList();
        }

        // Create view model for displaying the list of members with filtering and pagination.
        private MembersPagerViewModel CreateMembersViewModel(IEnumerable<Member> members, MemberFilterViewModel filter, Pager pager)
        {
            List<UserRoleViewModel> userdata = FetchUserData(members);

            // Create the view model
            return new MembersPagerViewModel
            {
                Members = userdata,
                PagerSearchViewModel = new PagerSearchViewModel
                {
                    Pager = pager,
                    SearchQuery = filter.SearchQuery ?? ""
                },
                MembershipSelectList = CreateSelectList(
                    Enum.GetValues(typeof(Membership))
                        .Cast<Membership>(),
                    filter.MembershipType,
                    "All"                // Default option in the dropdown.
                ),
                Filter = filter
            };
        }

        // Create select list for drop-down options (membership types).
        private static List<SelectListItem> CreateSelectList(IEnumerable<Membership> items, Membership? selectedValue, string defaultOption)
        {
            var selectList = items
                .OrderBy(i => i)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = i == selectedValue })
                .ToList();

            // Add default option at the top.
            selectList.Insert(0, new SelectListItem { Value = "", Text = defaultOption, Selected = selectedValue == null });
            return selectList;
        }

        // Show details for a specific member.
        public IActionResult ShowDetails(string id)
        {
            Member? member = memberRepsitory.GetById(id);

            return member != null ? View("ShowDetails", member) : View("NotFound");
        }

        // Helper method to get member by ID and return NotFound view if not found.
        private IActionResult GetMemberAndReturnView(string id, Func<string, IActionResult> viewAction)
        {
            Member member = memberRepsitory.GetById(id);
            if (member == null) return View("NotFound");
            return viewAction(id);
        }

        // Show borrowed books for a specific member.
        public IActionResult ShowBorrowed(string id)
        {
            return GetMemberAndReturnView(id, (memberId) =>
            {
                var bookBorrowed = borrowsCopyRepository.GetBorrowRecordsByMemberId(memberId);
                return View("ShowBorrowed", bookBorrowed);
            });
        }

        // Show reservations for a specific member.
        public IActionResult ShowReservations(string id)
        {
            return GetMemberAndReturnView(id, (memberId) =>
            {
                List<Reservation> reservations = borrowsCopyRepository.GetReservationsByMemberId(memberId);
                return View("ShowReservations", reservations);
            });
        }

        // Show penalties for a specific member.
        public IActionResult ShowPenalties(string id)
        {
            return GetMemberAndReturnView(id, (memberId) =>
            {
                List<Penalty> penalties = borrowsCopyRepository.GetPenaltiesByMemberId(memberId);
                return View("ShowPenalties", penalties);
            });
        }

        // Update member details
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            Member? member = memberRepsitory.GetById(id);

            if (member != null)
            {
                var membershipTypes = Enum.GetValues<Membership>()
                .Select(m => new SelectListItem
                {
                    Value = m.ToString(),
                    Text = m.ToString(),
                    Selected = m == member.MembershipType
                }).ToList();

                MemberMembershipViewModel memberAndMembershipViewModel = new MemberMembershipViewModel()
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    PhoneNumber = member.PhoneNumber,
                    DateOfMembership = member.DateOfMembership,
                    MembershipSelectList = membershipTypes,
                    IsActive = member.IsActive,
                    TotalBorrowedBooks = member.TotalBorrowedBooks
                };

                return View("Edit", memberAndMembershipViewModel);
            }
            else
            {
                return NotFound(); // Return NotFound if member does not exist.
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveEdit(MemberMembershipViewModel memberMembershipViewModel)
        {
            if (ModelState.IsValid)
            {
                Member member = memberRepsitory.GetById(memberMembershipViewModel.Id);

                if (member != null)
                {
                    member.FirstName = memberMembershipViewModel.FirstName;
                    member.LastName = memberMembershipViewModel.LastName;
                    member.PhoneNumber = memberMembershipViewModel.PhoneNumber;
                    member.Email = memberMembershipViewModel.Email;
                    member.IsActive = memberMembershipViewModel.IsActive;
                    member.TotalBorrowedBooks = memberMembershipViewModel.TotalBorrowedBooks;

                    memberRepsitory.Update(member);
                    return RedirectToAction("Index");
                }
            }
            return View("Edit", memberMembershipViewModel); // Return view if validation fails.
        }

    // Delete
    [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            Member? member = memberRepsitory.GetById(id);

            if (member == null)
            {
                return NotFound();
            }

            return View("Delete", member);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveDelete(string id)
        {
            memberRepsitory.Delete(id);
            memberRepsitory.Save();

            TempData["SuccessMessage"] = "The member has been deleted successfully!";
            return RedirectToAction("Index");
        }
    } 
}
