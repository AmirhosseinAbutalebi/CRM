using Crm.Domain.UserAgg.Enums;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, List<UserDto>>
    {
        private readonly CrmDbContext _context;
        public GetStudentQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
            .Where(r => r.Role == LevelUser.Student)
            .OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
            var result = UserMapper.UserMapToListDto(user);
            return result;
        }
    }
}

