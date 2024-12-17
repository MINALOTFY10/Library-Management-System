using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModel.BookViewModel
{
    public class BooksPagerViewModel
    {
        public PagerSearchViewModel PagerSearchViewModel { get; set; }

        public List<Book> books = [];

        public List<SelectListItem> LanguageSelectList { get; set; }
        public List<SelectListItem> PublisherSelectList { get; set; }

        public int GenreId { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<bool> IsBookAvailable { get; set; } = new List<bool>();

        public BookFilterViewModel Filter { get; set; }

    }
}
