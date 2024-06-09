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
        [HttpGet("GetUserByUserId/{userId}")]
        public async Task<UserDto?> GetUserByUserId(long userId)
        {
            return await _userFacade.GetUserByUserId(userId);
        }
        [HttpGet("GetListTeacher")]
        public async Task<List<UserDto>> GetTeachers()
        {
            return await _userFacade.GetTeachers();
        }
        [HttpGet("GetListStudent")]
        public async Task<List<UserDto>> GetStudents()
        {
            return await _userFacade.GetStudents();
        }
        [HttpGet("GetListUsers")]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userFacade.GetAll();
        }
    }
}
