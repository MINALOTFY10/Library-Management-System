using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    // Repository class for managing Penalty-related data.
    // Inherits from GenericRepository to provide basic CRUD functionality.
    public class PenaltyRepository : GenericRepository<Penalty>, IPenaltyRepository
    {
        private readonly ApplicationDbContext _context;
        public PenaltyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves a list of penalties for a specific member based on their MemberId.
        public List<Penalty> GetPenaltiesByMemberId(string id)
        {
            return [.. _context.Penalties.Where(p => p.MemberId == id)];
        }

    }
}
