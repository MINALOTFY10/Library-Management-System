using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public enum ConditionStatus
    {
        New,
        Good,
        Old,
        Damaged
    }

    public class BookCopy
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public ConditionStatus ConditionStatus { get; set; }
        public string Location { get; set; }
        public int Number { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; } 
        public Book Book { get; set; }

        public virtual ICollection<Penalty> Penalties { get; set; }
        public virtual ICollection<BorrowsCopy> BorrowsCopies { get; set; }
    }
}
