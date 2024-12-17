using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.ViewModel.BorrowsCopies
{
    public class BorrowedBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string GenreName { get; set; }

        public Genre Genre { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime DueDate { get; set; }

    }
}
