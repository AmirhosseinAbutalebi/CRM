using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly CrmDbContext _context;
        public GetUsersQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return UserMapper.UserMapToListDto(await _context.Users.ToListAsync(cancellationToken));
        }
    }
}
