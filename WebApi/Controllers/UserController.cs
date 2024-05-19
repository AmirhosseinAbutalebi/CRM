using Crm.Presentation.Facade.User;
using Crm.Query.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        /// <summary>
        /// get user by username
        /// </summary>
        /// <param name="username">with type string</param>
        /// <returns>userdto</returns>
        [HttpGet("GetUserByUsername")]
        public async Task<UserDto> GetUserByUserName(string username)
        {
            return await _userFacade.GetUserByUserName(username);
        }
        /// <summary>
        /// get list teachers
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListTeacher")]
        public async Task<List<UserDto>> GetTeachers()
        {
            return await _userFacade.GetTeachers();
        }
        /// <summary>
        /// get list students
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListStudent")]
        public async Task<List<UserDto>> GetStudents()
        {
            return await _userFacade.GetStudents();
        }
        /// <summary>
        /// get list users
        /// </summary>
        /// <returns>list userdto</returns>
        [HttpGet("GetListUsers")]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userFacade.GetAll();
        }
    }
}
