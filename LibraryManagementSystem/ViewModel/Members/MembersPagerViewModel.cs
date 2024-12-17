using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.Members
{
    public class MembersPagerViewModel
    {
        public List<UserRoleViewModel> Members { get; set; }

        public PagerSearchViewModel PagerSearchViewModel { get; set; }

        public List<SelectListItem> MembershipSelectList { get; set; }

        public MemberFilterViewModel Filter { get; set; }
    }
}
