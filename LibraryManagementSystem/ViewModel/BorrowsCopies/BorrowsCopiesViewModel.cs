using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModel
{
    public class BorrowsCopiesViewModel
    {
        public List<Member> members { get; set; }
        public List<Book> books { get; set; }

        public List<Book> chosenbooks { get; set; }

        [Required(ErrorMessage = "Please select a Member.")]
        public string MemberId { get; set; }

        [Required(ErrorMessage = "Please select a Book.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Book.")]
        public int? BookId { get; set; }

        [Required(ErrorMessage = "Please select at least one book.")]
        public List<int> BookIds { get; set; }

        public int BookCopyId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookStatus Status { get; set; }
    }
}
