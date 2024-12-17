using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{
    public enum Membership
    {
        Regular,
        Premium,
        Lifetime,
        Guest
    }
    public class Member : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfMembership { get; set; }
        public Membership MembershipType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public double TotalBorrowedBooks { get; set; }
        public double MaxBorrowLimit { get; set; }

        public virtual ICollection<Reservation>? Reservations { get; set; }
        public virtual ICollection<Penalty>? Penalties { get; set; }
        public virtual ICollection<BorrowsCopy>? BorrowCopies { get; set; }
    }
}
