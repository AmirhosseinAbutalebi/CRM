using Crm.Presentation.Facade.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Common.JwtConfig
{
    public class CustomJwtValidation
    {
        private readonly IUserFacade _userFacade;

        public CustomJwtValidation(IUserFacade facade)
        {
            _userFacade = facade;
        }

        public async Task Validate(TokenValidatedContext context)
        {
            var userId = context.Principal.GetUserId();
            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var token = await _userFacade.GetUserByToken(jwtToken);
            if (token == null)
            {
                context.Fail("Token NotFound");
                return;
            }

            var user = await _userFacade.GetUserByUserId(userId);
            if (user == null)
            {
                context.Fail("User InActive");
                return;
            }
        }
    }
}
