using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetNoOfPendingReservations()
        {
            return _context.Reservations
                .Where(r => r.Status == Status.Waiting).Count();
        }

        public List<Reservation> GetReservationsByMemberId(string id)
        {
            return _context.Reservations
                .Where(b => b.MemberId == id)
                .Include(b => b.Book)
                .ThenInclude(bc => bc.BookCopies)
                .Include(b => b.Member)
                .ToList();
        }
    }
}
