using Crm.Query.Users.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// use IConfiguration for set jwt token
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// constructor controller for define properties
        /// </summary>
        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// login controller that be use and use jwt 
        /// first check username exist or not 
        /// then check password correct or not
        /// claim jwt with username and role and id
        /// </summary>
        /// <param name="view">type loginviewmodel with parameter username and password</param>
        /// <returns>jwt token</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel view)
        {
            var user = await _mediator.Send(new GetUserByUsernameQuery(view.username));
            if (user == null)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");
            if (user.Password != view.password)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");

            var claims = new List<Claim>()
            {
                new Claim("username",user.UserName),
                new Claim("role",user.Role.ToString()),
                new Claim("id",user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"]));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credential);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);
        }
    }
}
