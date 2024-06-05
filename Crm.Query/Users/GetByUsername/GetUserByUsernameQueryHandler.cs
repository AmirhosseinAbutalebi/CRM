using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
    {
        private readonly CrmDbContext _context;
        public GetUserByUsernameQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f=> f.UserName == request.Username);
            return UserMapper.UserMapToDto(user);
        }
    }
}
