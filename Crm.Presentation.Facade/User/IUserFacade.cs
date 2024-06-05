using Crm.Query.Users.DTOs;
namespace Crm.Presentation.Facade.User
{
    public interface IUserFacade
    {
        Task<UserDto> GetUserByUserId(long userId);
        Task<List<UserDto>> GetTeachers();
        Task<List<UserDto>> GetStudents();
        Task<List<UserDto>> GetAll();
    }
}
