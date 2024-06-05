using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetStudent
{
    public record GetStudentQuery : IRequest<List<UserDto>>;

}
