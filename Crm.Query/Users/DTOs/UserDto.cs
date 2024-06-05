using Crm.Domain.UserAgg.Enums;
namespace Crm.Query.Users.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public LevelUser Role { get;  set; }
    }
}
