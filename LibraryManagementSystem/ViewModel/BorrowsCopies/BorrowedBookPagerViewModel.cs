using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.BorrowsCopies
{
    public class BorrowedBookPagerViewModel
    {
        public PagerSearchViewModel pagerSearchViewModel { get; set; }

        public List<BorrowedBookViewModel> Books = [];
        public int GenreId { get; set; }
        public List<SelectListItem> PublisherSelectList { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public PagerSearchViewModel PagerSearchViewModel { get; internal set; }
        public BookFilterViewModel Filter { get; set; }
    }
}
