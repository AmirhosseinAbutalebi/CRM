using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetByUsername
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetUserByUsernameQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return user with username that get it
        /// </summary>
        /// <returns>userdto</returns>
        public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f=> f.UserName == request.Username);
            return UserMapper.UserMapToDto(user);
        }
    }
}
