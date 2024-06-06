using Crm.Domain.UserAgg.Enums;
using MediatR;

namespace Crm.Application.User.Register
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserCommand(string userName, string password, string firstName, string lastName, LevelUser role)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public LevelUser Role { get; private set; }
    }
}
