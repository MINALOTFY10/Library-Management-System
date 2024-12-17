using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModel.Members
{
    public class MemberFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public string? Role { get; set; }
        public Membership? MembershipType { get; set; } 
        public bool? IsActive { get; set; }
        public DateTime? MembershipFrom { get; set; }
        public DateTime? MembershipTo { get; set; }
        public DateTime? ExpirationFrom { get; set; }
        public DateTime? ExpirationTo { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}
