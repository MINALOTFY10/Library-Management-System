using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookCopyRepository : IGenericRepository<BookCopy>
    {
        BookCopy? GetBookByBookCopyId(int Id);
        List<BookCopy> GetBookCopiesByBookId(int bookId);
        List<BookCopy> GetAvailableBookCopiesByBookIds(IEnumerable<int> bookIds);
    }
}
