using Crm.Application.User.AddToken;
using Crm.Application.User.Register;
using Crm.Application.User.RemoveToken;
using Crm.Query.Users.DTOs;
namespace Crm.Presentation.Facade.User
{
    public interface IUserFacade
    {
        Task RegisterUser(RegisterUserCommand user);
        Task AddUserToken(AddTokenCommand token);
        Task RemoveUserToken(RemoveTokenCommand token);

        Task<UserDto?> GetUserByUserId(long userId);
        Task<UserTokenDto> GetUserByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserByToken(string jwtToken);
        Task<List<UserDto>> GetTeachers();
        Task<List<UserDto>> GetStudents();
        Task<List<UserDto>> GetAll();
    }
}
