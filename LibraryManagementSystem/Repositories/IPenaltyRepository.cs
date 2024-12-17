using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IPenaltyRepository : IGenericRepository<Penalty>
    {
        public List<Penalty> GetPenaltiesByMemberId(string id);
    }
}
