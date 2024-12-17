namespace LibraryManagementSystem.Models
{
    public enum Status
    {
        Waiting,
        Expired,
        Collected,
        Cancelled,
        None
    }

    public class Reservation 
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Status Status { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string MemberId{ get; set; }
        public Member Member { get; set; } 
    }
}
