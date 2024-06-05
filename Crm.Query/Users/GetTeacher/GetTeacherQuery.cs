using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetTeacher
{
    public record GetTeacherQuery : IRequest<List<UserDto>>;

}
