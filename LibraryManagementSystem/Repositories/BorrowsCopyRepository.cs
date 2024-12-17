using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    // Repository class for managing BorrowsCopy entities.
    // Inherits from GenericRepository and implements IBorrowsCopyRepository for specific operations related to BorrowsCopy.
    public class BorrowsCopyRepository : GenericRepository<BorrowsCopy>, IBorrowsCopyRepository
    {
        private readonly ApplicationDbContext _context;
        public BorrowsCopyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves a specific borrow record based on memberId and bookId
        public BorrowsCopy? GetByIds(string memberId, int bookId)
        {
            List<BorrowsCopy> borrowsCopies = [.. _context.BorrowsCopies
                .Where(b => b.MemberId == memberId)
                .Include(b => b.BookCopy)];

            return borrowsCopies.FirstOrDefault(bc => bc.BookCopy.BookId == bookId);
        }

        // Retrieves all borrow records for a specific member
        public List<BorrowsCopy> GetBorrowRecordsByMemberId(string memberId)
        {
            return [.. _context.BorrowsCopies
                .Where(b => b.MemberId == memberId)
                .Include(b => b.BookCopy)
                .ThenInclude(bc => bc.Book)];
        }

        // Retrieves all reservations for a specific member
        public List<Reservation> GetReservationsByMemberId(string id)
        {
            var lol = _context.Reservations;

            return [.. _context.Reservations
                .Where(b => b.MemberId == id)
                .Include(b => b.Book)
                .ThenInclude(bc => bc.BookCopies)];
        }

        // Retrieves all penalties for a specific member
        public List<Penalty> GetPenaltiesByMemberId(String id)
        {
            return [.. _context.Penalties
                .Where(b => b.MemberId == id)
                .Include(b => b.BookCopy)
                .ThenInclude(bc => bc.Book)];
        }

        // Get Numbers of Borrowed Books in the last Month
        public int GetNoOfBorrowedBooksMonthly()
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            return _context.BorrowsCopies
                .Where(b => b.BorrowDate >= lastMonth)
                .Count();
        }

        // Retrieves the number of books borrowed in the last year
        public int GetNoOfBorrowedBooksYearly()
        {
            DateTime lastYear = DateTime.Now.AddYears(-1);
            return _context.BorrowsCopies
                .Where(b => b.BorrowDate >= lastYear)
                .Count();
        }

        // Calculates the percentage of overdue books among all currently borrowed books
        public double GetOverdueBooksPercentage()
        {
            int totalBorrowedBooks = _context.BorrowsCopies.Where(b => b.ReturnDate == null).Count();
            int totalOverdueBooks = _context.BorrowsCopies
                .Where(b => b.DueDate < DateTime.Now && b.ReturnDate == null)
                .Count();
            return (double)totalOverdueBooks / totalBorrowedBooks * 100;
        }

        // Retrieves the number of books borrowed each month over the last year
        public List<int> GetBorrowedBooksMonthlyList()
        {
            List<int> MonthsList = new(new int[12]);
            for (int i = 0; i < 12; i++)
            {
                DateTime month = DateTime.Now.AddMonths(-i);
                int monthIndex = 11 - i;  
                MonthsList[monthIndex] = _context.BorrowsCopies
                    .Where(b => b.BorrowDate.Month == month.Month && b.BorrowDate.Year == month.Year)
                    .Count();
            }
            return MonthsList;
        }

        // Deletes a borrow record for a specific member and book
        public void Delete(string memberId, int bookId)
        {
            BorrowsCopy? borrowsCopy = GetByIds(memberId, bookId);
            if (borrowsCopy != null)
            {
                _context.BorrowsCopies.Remove(borrowsCopy);
            }
        }
    }
}
