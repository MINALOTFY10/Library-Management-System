using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Language { get; set; }
        public DateTime AddedDate { get; set; }
        public int TotalBorrowCount { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}
