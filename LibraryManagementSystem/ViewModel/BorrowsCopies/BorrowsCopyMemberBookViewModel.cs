using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel
{
    public class BorrowsCopyMemberBookViewModel
    {
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookStatus Status { get; set; }

        public string MemberId { get; set; }
        public string MemberName { get; set; }

        public int BookCopyId { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}
