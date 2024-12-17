using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController(
        IBookRepository bookRepository,
        IMemberRepository memberRepository,
        IBorrowsCopyRepository borrowsCopyRepository,
        IReservationRepository reservationRepository,
        SignInManager<Member> signInManager) : Controller
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMemberRepository _memberRepository = memberRepository;
        private readonly IBorrowsCopyRepository _borrowsCopyRepository = borrowsCopyRepository;
        private readonly IReservationRepository _reservationRepository = reservationRepository;
        private readonly SignInManager<Member> _signInManager = signInManager;

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return Redirect("~/Identity/Account/Login");

            var homeViewModel = new DashboardViewModel
            {
                BorrowedBooksMonthly = _borrowsCopyRepository.GetNoOfBorrowedBooksMonthly(),
                BorrowedBooksAnnually = _borrowsCopyRepository.GetNoOfBorrowedBooksYearly(),
                OverdueBooksPercentage = _borrowsCopyRepository.GetOverdueBooksPercentage(),
                PendingReservations = _reservationRepository.GetNoOfPendingReservations(),
                BorrowedBooksEachMonthlyList = _borrowsCopyRepository.GetBorrowedBooksMonthlyList(),
                GenreBookCount = _bookRepository.GetGenreBookCount(),
                NewMembersMonthlyList = _memberRepository.GetNewMembersMonthlyList(),
                Top5BorrowedBooks = _bookRepository.GetTop10BorrowedBooks()
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel);
        }

        public IActionResult CustomNotFound()
        {
            return View("NotFound");
        }
    }
}
