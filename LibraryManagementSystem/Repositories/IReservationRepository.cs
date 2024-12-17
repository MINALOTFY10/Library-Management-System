using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        public int GetNoOfPendingReservations();
        public List<Reservation> GetReservationsByMemberId(string id);
    }
}
