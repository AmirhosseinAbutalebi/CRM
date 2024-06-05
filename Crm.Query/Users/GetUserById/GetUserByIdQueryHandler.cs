using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Users.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly CrmDbContext _context;
        public GetUserByIdQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(r=> r.Id == request.Id).FirstOrDefaultAsync();
            var result = UserMapper.UserMapToDto(user);

            return result;
        }
    }
}
