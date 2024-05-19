using Crm.Domain.UserAgg;
using Crm.Domain.UserAgg.Repository;
using Microsoft.EntityFrameworkCore;
namespace Crm.Infrastructure.Persistent.Ef.User
{
    /// <summary>
    /// infrastucre IUserRepository that define in domain
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// use database for actions need to use
        /// </summary>
        private readonly CrmDbContext _context;

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="context">type database</param>
        public UserRepository(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// for add to database
        /// </summary>
        /// <param name="user">type of Users</param>
        public void Add(Users user)
        {
            _context.Add(user);
        }
        /// <summary>
        /// for delete by user
        /// </summary>
        /// <param name="user">user with type Users</param>
        public void Delete(Users user)
        {
            _context.Remove(user);
        }
        /// <summary>
        /// get user with id
        /// </summary>
        /// <param name="id">id user with type long</param>
        /// <returns>users</returns>
        public async Task<Users> GetById(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        /// <summary>
        /// for save data in database
        /// </summary>
        /// <returns>task</returns>
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// for update database
        /// </summary>
        /// <param name="user">type Users</param>
        public void Update(Users user)
        {
            _context.Update(user);
        }
        /// <summary>
        /// get user by username
        /// </summary>
        /// <param name="username">username user and type string</param>
        /// <returns> task of users</returns>
        public async Task<Users> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.UserName == username);
        }

        /// <summary>
        /// check user exist or not
        /// </summary>
        /// <param name="username">username user with type string</param>
        /// <returns>true or false if exist user or not</returns>
        public bool UserExists(string username)
        {
            return _context.Users.Any(Users => Users.UserName == username);
        }

    }
}
