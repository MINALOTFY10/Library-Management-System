using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{

    public enum BookStatus
    {
        Borrowed,
        Returned,
        None
    }

    public class BorrowsCopy
    {         
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookStatus Status {  get; set; }

        public required string MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int BookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; }
    }
}
