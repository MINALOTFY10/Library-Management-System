using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel
{
    public class UserRoleViewModel
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfMembership { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int MaxBorrowLimit { get; set; }
        public Membership MembershipType { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public string Role { get; set; }
    }
}
