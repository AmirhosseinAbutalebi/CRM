using Crm.Domain.UserAgg;
using Crm.Domain.UserAgg.Repository;
using Crm.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Persistent.Ef.User
{
    internal class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(CrmDbContext context) : base(context)
        {
        }
        public void Delete(Users user)
        {
            _context.Remove(user);
        }

        public async Task<Users> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(r => r.UserName == username);
        }

        public bool UserExists(long userId)
        {
            return _context.Users.Any(r=> r.Id == userId);
        }
    }
}
