using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel.Reservations
{
    public class ReservationFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public Status? Status { get; set; }
        public DateTime? ReservationDateFrom { get; set; }
        public DateTime? ReservationDateTo { get; set; }
        public DateTime? ExpirationDateFrom { get; set; }
        public DateTime? ExpirationDateTo { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}
