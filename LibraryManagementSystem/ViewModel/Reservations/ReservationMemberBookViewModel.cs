using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel.Reservations
{
    public class ReservationMemberBookViewModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Status Status { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
    }
}
