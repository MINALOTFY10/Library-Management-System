using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel
{
    public class BorrowsCopiesFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public BookStatus? Status { get; set; }
        public DateTime? BorrowDateFrom { get; set; }
        public DateTime? BorrowDateTo { get; set; }
        public DateTime? DueDateFrom { get; set; }
        public DateTime? DueDateTo { get; set; }
        public DateTime? ReturnDateFrom { get; set; }
        public DateTime? ReturnDateTo { get; set; }
        public int MemberId { get; set; }
        public int BookCopyId { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}
