using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Penalties
{
    public class PenaltiesPagerViewModel
    {
        public List<PenaltyMemberBookViewModel> Penalties { get; set; }

        public PagerSearchViewModel PagerSearchViewModel { get; set; }

        public List<SelectListItem> PenaltyTypesSelectList { get; set; }

        public PenaltyFilterViewModel Filter { get; set; }
    }
}
