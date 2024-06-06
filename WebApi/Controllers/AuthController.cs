using Crm.Presentation.Facade.User;
using Crm.Query.Users.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.JwtConfig;
using WebApi.Common.SecurityUtils;
using WebApi.Common.ViewModel;
using Crm.Application.User.Register;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;
        public AuthController(IMediator mediator, IConfiguration configuration, IUserFacade userFacade)
        {
            _mediator = mediator;
            _configuration = configuration;
            _userFacade = userFacade;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel view)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var user = await _mediator.Send(new GetUserByUsernameQuery(view.Username));
            if (user == null)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");

            if (Sha256Hash.IsCompare(user.Password, view.Password) == false)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
           
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel view)
        {
            var user = await _mediator.Send(new GetUserByUsernameQuery(view.Username));
            if (user != null)
                return BadRequest("چنین کاربری وجود دارد لطفا نام کاربری را تغییر دهید");
            var command = new RegisterUserCommand(view.Username, view.Password, view.FirstName, view.LastName, view.Role);
            await _userFacade.RegisterUser(command);
            return Ok("کاربر با موفقیت ایجاد شد");
        }
    }
}
