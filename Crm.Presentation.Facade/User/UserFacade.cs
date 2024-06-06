using Crm.Application.User.Register;
using Crm.Query.Users.DTOs;
using Crm.Query.Users.GetStudent;
using Crm.Query.Users.GetTeacher;
using Crm.Query.Users.GetUserById;
using Crm.Query.Users.GetUsers;
using MediatR;
namespace Crm.Presentation.Facade.User
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RegisterUser(RegisterUserCommand user)
        {
            await _mediator.Send(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await _mediator.Send(new GetUsersQuery());
        }
        public async Task<List<UserDto>> GetStudents()
        {
            return await _mediator.Send(new GetStudentQuery());
        }
        public async Task<List<UserDto>> GetTeachers()
        {
            return await _mediator.Send(new GetTeacherQuery());
        }
        public async Task<UserDto> GetUserByUserId(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }
    }
}
