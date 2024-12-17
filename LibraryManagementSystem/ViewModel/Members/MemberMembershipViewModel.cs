using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Members
{
    public class MemberMembershipViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Membership MembershipType { get; set; }
        public DateTime DateOfMembership { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public double TotalBorrowedBooks { get; set; }
        public double MaxBorrowLimit { get; set; }
        public List<SelectListItem> MembershipSelectList { get; set; }

    }
}
