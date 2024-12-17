using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Penalties
{
    public class PenaltyMemberBookViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public PenaltyType? PenaltyType { get; set; }
        public double PenaltyAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool PaidStatus { get; set; }
        public List<SelectListItem> PenaltyTypeSelectList { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
    }
}
