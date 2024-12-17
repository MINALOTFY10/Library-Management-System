using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    // Repository class for managing Book entities.
    // Inherits from GenericRepository and implements IBookRepository for specific operations related to books.
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves detailed information about a specific book by its ID.
        public Book? GetBookDetailsById(int id)
        {
            return _context.Books.Include(b => b.Genre)
                .Include(r => r.Reservations)
                .Include(b => b.BookCopies)
                .ThenInclude(c => c.BorrowsCopies)
                .ThenInclude(bc => bc.Member)
                .FirstOrDefault(b => b.Id == id);
        }

        // Retrieves a book by its title.
        public Book? GetBookBytitle(string title)
        {
            return _context.Books
                .FirstOrDefault(b => b.Title == title);
        }

        // Retrieves the top 10 most borrowed books and their borrow counts.
        public Dictionary<string, int> GetTop10BorrowedBooks()
        {
            var topBorrowedBooksCount = new Dictionary<string, int>();

            var books  = _context.Books.OrderByDescending(b => b.TotalBorrowCount).Take(10).ToList();

            foreach (var book in books)
            {
                topBorrowedBooksCount.Add(book.Title, book.TotalBorrowCount);
            }

            return topBorrowedBooksCount;
        }

        // Retrieves the count of books for each genre.
        public Dictionary<string, int> GetGenreBookCount()
        {
            var genreBookCount = new Dictionary<string, int>();
            var genres = _context.Genres.ToList();
            foreach (var genre in genres)
            {
                genreBookCount.Add(genre.Name, _context.Books.Count(b => b.GenreId == genre.Id));
            }
            return genreBookCount;
        }

        // Retrieves a list of books by their IDs.
        public List<Book> GetByIds(IEnumerable<int> ids)
        {
            return [.. _context.Books.Where(b => ids.Contains(b.Id))];
        }
    }
}
 