using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        public List<int> GetNewMembersMonthlyList();
    }
}
