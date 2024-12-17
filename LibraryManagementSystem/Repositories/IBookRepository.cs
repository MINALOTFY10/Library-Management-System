using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Book? GetBookDetailsById(int id);
        public Book? GetBookBytitle(string title);
        public Dictionary<string, int> GetTop10BorrowedBooks();
        public Dictionary<string, int> GetGenreBookCount();
        public List<Book> GetByIds(IEnumerable<int> ids);
    }
}
