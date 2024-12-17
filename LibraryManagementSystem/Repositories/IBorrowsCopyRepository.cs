using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBorrowsCopyRepository : IGenericRepository<BorrowsCopy>
    {
        public BorrowsCopy? GetByIds(string memberId, int bookId);
        public void Delete(string memberId, int bookId);
        public List<BorrowsCopy> GetBorrowRecordsByMemberId(string id);
        public List<Reservation> GetReservationsByMemberId(string id);
        public List<Penalty> GetPenaltiesByMemberId(string id);
        public int GetNoOfBorrowedBooksMonthly();
        public int GetNoOfBorrowedBooksYearly();
        public double GetOverdueBooksPercentage();
        public List<int> GetBorrowedBooksMonthlyList();
    }
}
