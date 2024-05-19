using Crm.Query.Users.DTOs;
using Crm.Query.Users.GetByUsername;
using Crm.Query.Users.GetStudent;
using Crm.Query.Users.GetTeacher;
using Crm.Query.Users.GetUserById;
using Crm.Query.Users.GetUsers;
using MediatR;
namespace Crm.Presentation.Facade.User
{
    /// <summary>
    /// service for UserFacade and infrastructure it with interface 
    /// IUserFacade and for infrastructure need mediatr
    /// </summary>
    internal class UserFacade : IUserFacade
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor UserFacade
        /// </summary>
        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// for get all users
        /// </summary>
        /// <returns>list userdto</returns>
        public async Task<List<UserDto>> GetAll()
        {
            return await _mediator.Send(new GetUsersQuery());
        }
        /// <summary>
        /// get list of studetns
        /// </summary>
        /// <returns>list userdto</returns>
        public async Task<List<UserDto>> GetStudents()
        {
            return await _mediator.Send(new GetStudentQuery());
        }
        /// <summary>
        /// get list of teachers
        /// </summary>
        /// <returns>list userdto</returns>
        public async Task<List<UserDto>> GetTeachers()
        {
            return await _mediator.Send(new GetTeacherQuery());
        }
        /// <summary>
        /// get user by user name 
        /// </summary>
        /// <param name="username">with type string</param>
        /// <returns>userdto</returns>
        public async Task<UserDto> GetUserByUserName(string username)
        {
            return await _mediator.Send(new GetUserByUsernameQuery(username));
        }
        /// <summary>
        /// get user by user id
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>userdto</returns>
        public async Task<UserDto> GetUserByUserId(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }
    }
}
