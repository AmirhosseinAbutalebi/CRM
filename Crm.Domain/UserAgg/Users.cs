using Crm.Domain.Shared;
using Crm.Domain.UserAgg.Enums;
namespace Crm.Domain.UserAgg
{
    public class Users : AggregateRoot
    {
        public Users(string userName, string password, string firstName, string lastName, LevelUser role)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Tokens = new List<UserToken>();
        }
        private Users()
        {

        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public LevelUser Role { get; private set; }
        public ICollection<UserToken> Tokens { get; }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime expireToken, DateTime expireRefreshToken, string device)
        {
            var activeTokenCount = Tokens.Count(c=> c.ExpireRefreshToken > DateTime.Now);
            if (activeTokenCount > 3)
                throw new InvalidDataException("فقط سه کاربر به طور همزمان می توانند لاگین کنند");

            var token = new UserToken(hashJwtToken, hashRefreshToken, expireToken, expireRefreshToken, device);
            token.UsersId = Id;
            Tokens.Add(token);
        }

        public string removeToken(long id)
        {
            var token = Tokens.FirstOrDefault(t=> t.Id == id);
            if (token == null)
                throw new InvalidDataException("چنین توکنی وجود ندارد");
            Tokens.Remove(token);
            return token.HashJwtToken;
        }
    }
}
