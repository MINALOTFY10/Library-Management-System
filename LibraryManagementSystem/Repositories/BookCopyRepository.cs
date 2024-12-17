using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    // Repository class for managing BookCopy entities.
    // Inherits from a GenericRepository to provide base CRUD operations and implements IBookCopyRepository for specific functionality.
    public class BookCopyRepository : GenericRepository<BookCopy>, IBookCopyRepository
    {
        private readonly ApplicationDbContext _context;

        public BookCopyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves a specific BookCopy by its unique ID, including its associated Book entity.
        public BookCopy? GetBookByBookCopyId(int Id)
        {
            return _context.BookCopies.Where(bc => bc.Id == Id).Include(bc => bc.Book).FirstOrDefault();
        }

        // Retrieves all BookCopy records associated with a specific Book ID.
        public List<BookCopy> GetBookCopiesByBookId(int bookId)
        {
            return [.. _context.BookCopies.Where(bc => bc.BookId == bookId)];
        }

        // Retrieves available BookCopy records for a list of Book IDs.
        public List<BookCopy> GetAvailableBookCopiesByBookIds(IEnumerable<int> bookIds)
        {
            return [.. _context.BookCopies.Where(bc => bookIds.Contains(bc.BookId) && bc.IsAvailable)];
        }
    }
}
