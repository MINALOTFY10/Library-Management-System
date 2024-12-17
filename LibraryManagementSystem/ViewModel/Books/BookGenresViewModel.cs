using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.ViewModel.BookViewModel
{
    public class BookGenresViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title cannot be shorter than 2 characters or longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Author cannot be shorter than 2 characters or longer than 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }


        [Required(ErrorMessage = "Publisher is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Publisher cannot be shorter than 2 characters or longer than 100 characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Published date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [CustomDateValidation(ErrorMessage = "Published date cannot be in the future.")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Language cannot be shorter than 2 characters or longer than 100 characters")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Added date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [CustomDateValidation(ErrorMessage = "Added date cannot be in the future.")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Total Borrow Count is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Borrow Count cannot be negative")]
        public int TotalBorrowCount { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }


    }
}
