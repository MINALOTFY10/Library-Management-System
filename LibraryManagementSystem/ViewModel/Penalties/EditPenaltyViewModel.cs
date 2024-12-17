using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Penalties
{
    public class EditPenaltyViewModel
    {
        public int Id { get; set; }
        public PenaltyType? PenaltyType { get; set; }
        public double PenaltyAmount { get; set; }
        public bool PaidStatus { get; set; }
    }
}
