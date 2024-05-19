using Crm.Query.Users.DTOs;
namespace Crm.Presentation.Facade.User
{
    /// <summary>
    /// define interface for user that use facade in project and all command 
    /// and query need till define and in userfacade impelement and use it
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// get user by username and need string username 
        /// </summary>
        /// <param name="username">with type string</param>
        /// <returns>userdto</returns>
        Task<UserDto> GetUserByUserName(string username);
        /// <summary>
        /// get list of teachers
        /// </summary>
        /// <returns>list userdto</returns>
        Task<List<UserDto>> GetTeachers();
        /// <summary>
        /// get list of students
        /// </summary>
        /// <returns>list userdto</returns>
        Task<List<UserDto>> GetStudents();
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns>list userdto</returns>
        Task<List<UserDto>> GetAll();
    }
}
