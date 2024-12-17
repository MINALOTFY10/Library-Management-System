using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    // MemberRepository inherits from a generic repository and implements IMemberRepository.
    // This repository is specific to operations related to the 'Member' entity.
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public MemberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the count of new members for each month of the year.
        /// </summary>
        /// <returns> A list of integers where each index (0-11) represents the number of new members for a month (Jan-Dec).</returns>
        public List<int> GetNewMembersMonthlyList()
        {
            List<int> newMembersMonthlyList = [];
            for (int i = 1; i <= 12; i++)
            {
                newMembersMonthlyList.Add(_context.Members
                    .Where(m => m.DateOfMembership.Month == i)
                    .Count());
            }
            return newMembersMonthlyList;
        }
    }
}
