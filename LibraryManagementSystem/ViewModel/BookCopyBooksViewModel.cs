using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.ViewModel
{
    [Index(nameof(Number), IsUnique = true)]
    public class BookCopyBooksViewModel
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public int Number { get; set; }

        [Required(ErrorMessage = "Condition Status is required")]
        public ConditionStatus ConditionStatus { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Location cannot be shorter than 2 characters or longer than 100 characters")]
        public string Location { get; set; }

        public string BookName { get; set; }

        public int BookId { get; set; }
    }
}
