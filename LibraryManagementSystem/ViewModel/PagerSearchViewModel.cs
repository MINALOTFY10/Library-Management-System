using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModel
{
    public class PagerSearchViewModel
    {
        public string SearchQuery { get; set; } = "";
        public Pager? Pager { get; set; }
    }
}
