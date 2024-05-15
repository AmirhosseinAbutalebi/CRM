using Crm.Query.Users.DTOs;
using Crm.Query.Users.GetByUsername;
using Crm.Query.Users.GetStudent;
using Crm.Query.Users.GetTeacher;
using Crm.Query.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// constructor TicketController
        /// </summary>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// get user by username
        /// </summary>
        /// <param name="username">with type string</param>
        /// <returns>userdto</returns>
        [HttpGet("GetUserByUsername")]
        public async Task<UserDto> GetUserByUserName(string username)
        {
            return await _mediator.Send(new GetUserByUsernameQuery(username));
        }
        /// <summary>
        /// get list teachers
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListTeacher")]
        public async Task<List<UserDto>> GetTeachers()
        {
            return await _mediator.Send(new GetTeacherQuery());
        }
        /// <summary>
        /// get list students
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListStudent")]
        public async Task<List<UserDto>> GetStudents()
        {
            return await _mediator.Send(new GetStudentQuery());
        }
        /// <summary>
        /// get list users
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListUsers")]
        public async Task<List<UserDto>> GetAll()
        {
            return await _mediator.Send(new GetUsersQuery());
        }
    }
}
