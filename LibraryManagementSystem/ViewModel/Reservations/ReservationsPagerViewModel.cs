using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Reservations
{
    public class ReservationsPagerViewModel
    {
        public List<ReservationMemberBookViewModel> Reservations { get; set; }

        public PagerSearchViewModel PagerSearchViewModel { get; set; }

        public List<SelectListItem> StatusSelectList { get; set; }

        public ReservationFilterViewModel Filter { get; set; }
    }
}
