using Crm.Domain.UserAgg.Enums;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetTeacher
{
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, List<UserDto>>
    {
        private readonly CrmDbContext _context;
        public GetTeacherQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
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
