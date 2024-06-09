using Crm.Presentation.Facade.User;
using Crm.Query.Users.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.JwtConfig;
using WebApi.Common.ViewModel;
using Crm.Application.User.Register;
using WebApi.Common.ResultDto;
using Crm.Application.Shared;
using Crm.Application.User.AddToken;
using WebApi.Common.GetDevice;
using Crm.Application.User.RemoveToken;
using Crm.Query.Users.DTOs;
using Crm.Query.Users.GetUserById;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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

            var result = await AddTokenAndGenerateJwtToken(user);

            return Ok(result);
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

        
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var jwtToken = await HttpContext.GetTokenAsync("access_token");
            if (jwtToken == null)
                throw new InvalidDataException("token not found");

            var result = await _userFacade.GetUserByToken(jwtToken);

            if (result == null)
                return NotFound("چنین کاربری یافت نشده است");

            var token = new RemoveTokenCommand(result.UsersId, result.Id);

            await _userFacade.RemoveUserToken(token);

            return Ok();
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            
            var result = await _userFacade.GetUserByRefreshToken(refreshToken);

            if (result == null)
                return NotFound("چنین توکنی یافت نشد");

            if (result.ExpireToken > DateTime.Now)
                return BadRequest("توکن هنوز منقضی نشده است");

            if (result.ExpireRefreshToken < DateTime.Now)
                return BadRequest("زمان رفرش توکن تمام شده است مجددا ورود نماید");

            var user = await _mediator.Send(new GetUserByIdQuery(result.UsersId));

            var token = new RemoveTokenCommand(result.UsersId, result.Id);

            await _userFacade.RemoveUserToken(token);

            var loginResult = await AddTokenAndGenerateJwtToken(user);

            return Ok(loginResult);

        }
        private async Task<LoginResultDto> AddTokenAndGenerateJwtToken(UserDto user)
        {
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var resfreshToken = Guid.NewGuid().ToString();

            var hashToken = Sha256Hash.Hash(token);
            var hashRefreshToken = Sha256Hash.Hash(resfreshToken);


            var device = "";
            var header = HttpContext.Request.Headers["user-agent"].ToString();
            if (header != null)
                device = GetUserDevice.DeviceName(header);
            else
                device = "";
            var command = new AddTokenCommand(user.Id, hashToken, hashRefreshToken, DateTime.Now.AddDays(7),
                DateTime.Now.AddDays(8), device);

            try
            {
                 await _userFacade.AddUserToken(command);
            }
            catch
            {
                throw new InvalidDataException("تعداد کاربران فعال فقط ۴ می باشد و بیشتر نمی توانند ورود کنند");
            }

            var result = new LoginResultDto()
            {
                RefreshToken = resfreshToken,
                Token = token
            };

            return result;
        }
    }
}

