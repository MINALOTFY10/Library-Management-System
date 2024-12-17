using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel
{
    public class DashboardViewModel
    {
        public int BorrowedBooksMonthly { get; set; }
        public int BorrowedBooksAnnually { get; set; }
        public double OverdueBooksPercentage { get; set; }
        public int PendingReservations { get; set; }

        // Showing the number of books borrowed each month
        public List<int> BorrowedBooksEachMonthlyList { get; set; } = new List<int>(new int[12]);

        // Store the number of Books in each Genre
        public Dictionary<string, int> GenreBookCount { get; set; }

        // Number of new members each month
        public List<int> NewMembersMonthlyList { get; set; } = new List<int>(new int[12]);

        // Top 5 borrowed books
        public Dictionary<string, int> Top5BorrowedBooks { get; set; }
    }
}
