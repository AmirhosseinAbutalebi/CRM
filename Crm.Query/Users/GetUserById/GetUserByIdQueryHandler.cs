using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetUserById
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetUserByIdQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return user by id
        /// </summary>
        /// <returns>userdto</returns>
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(r=> r.Id == request.Id).FirstOrDefaultAsync();
            var result = UserMapper.UserMapToDto(user);

            return result;
        }
    }
}
