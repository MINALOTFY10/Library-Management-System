using System.Data.SqlTypes;

namespace LibraryManagementSystem.Models
{
    public enum PenaltyType
    {
        Damaged,
        Lost,
        Late
    }

    public class Penalty
    { 
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public Double PenaltyAmount { get; set; }
        public DateTime DueDate { get; set; }
        public PenaltyType PenaltyType { get; set; }
        public DateTime? ReturnDate {  get; set; }
        public bool PaidStatus { get; set; }

        public required string MemberId { get; set; }
        public Member Member { get; set; }

        public int BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; }
    }
}
