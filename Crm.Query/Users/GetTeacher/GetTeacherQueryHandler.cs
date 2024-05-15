using Crm.Domain.UserAgg.Enums;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Query.Users.GetTeacher
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, List<UserDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetTeacherQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list user that are teacher
        /// </summary>
        /// <returns>list userdto</returns>
        public async Task<List<UserDto>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
            .Where(r => r.Role == LevelUser.Teacher)
            .OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
            var result =  UserMapper.UserMapToListDto(user);
            return result;
        }
    }
}
