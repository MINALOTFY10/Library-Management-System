using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModel.BookViewModel
{
    public class BookFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public int GenreId { get; set; }
        public string? Language { get; set; }

        [Display(Name = "Publisher")]
        public string? Publisher { get; set; }

        [Display(Name = "Published From")]
        public DateTime? PublishedFrom { get; set; }

        [Display(Name = "Published To")]
        public DateTime? PublishedTo { get; set; }

        [Display(Name = "Borrowed From")]
        public DateTime? BorrowedFrom { get; set; }

        [Display(Name = "Borrowed To")]
        public DateTime? BorrowedTo { get; set; }

        [Display(Name = "Returned From")]
        public DateTime? ReturnedFrom { get; set; }

        [Display(Name = "Returned To")]
        public DateTime? ReturnedTo { get; set; }

        [Display(Name = "Due From")]
        public DateTime? DueFrom { get; set; }

        [Display(Name = "Due To")]
        public DateTime? DueTo { get; set; }

        public bool? IsAvailable { get; set; }

        public bool? IsReturned { get; set; }

        [Display(Name = "Sort By")]
        public string? SortBy { get; set; }

        public string? SortOrder { get; set; }
    }
}
