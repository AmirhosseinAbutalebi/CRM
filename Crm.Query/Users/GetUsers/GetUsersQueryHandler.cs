using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetUsers
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetUsersQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list user that are student
        /// </summary>
        /// <returns>list userdto</returns>
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return UserMapper.UserMapToListDto(await _context.Users.ToListAsync(cancellationToken));
        }
    }
}
