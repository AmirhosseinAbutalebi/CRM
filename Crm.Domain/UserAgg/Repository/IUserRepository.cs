using Crm.Domain.Shared;

namespace Crm.Domain.UserAgg.Repository
{
    public interface IUserRepository : IBaseRepositroy<Users>
    {
        void Delete(Users user);
        Task<Users> GetByUserName(string username);
        bool UserExists(long userId);
    }
}
