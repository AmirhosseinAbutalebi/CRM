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
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

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
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
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
