using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel
{
    public class BorrowsCopiesPagerViewModel
    {
        public List<BorrowsCopyMemberBookViewModel> BorrowsCopies { get; set; }

        public PagerSearchViewModel PagerSearchViewModel { get; set; }

        public List<SelectListItem> StatusSelectList { get; set; }

        public BorrowsCopiesFilterViewModel Filter { get; set; }
    }
}
