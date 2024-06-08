using Crm.Application.Shared;
using Crm.Application.User.AddToken;
using Crm.Application.User.Register;
using Crm.Application.User.RemoveToken;
using Crm.Query.Users.DTOs;
using Crm.Query.Users.GetStudent;
using Crm.Query.Users.GetTeacher;
using Crm.Query.Users.GetUserById;
using Crm.Query.Users.GetUsers;
using Crm.Query.Users.UserToken.GetUserByRefreshToken;
using Crm.Query.Users.UserToken.GetUserByToken;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
namespace Crm.Presentation.Facade.User
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;
        public UserFacade(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        public async Task RegisterUser(RegisterUserCommand user)
        {
            await _mediator.Send(user);
        }
        public async Task AddUserToken(AddTokenCommand token)
        {
            await _mediator.Send(token);
        }
        public async Task RemoveUserToken(RemoveTokenCommand token)
        {
            var result = await _mediator.Send(token);

            await _distributedCache.RemoveAsync(CacheKeys.UserToken(result));
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
        public async Task<UserDto?> GetUserByUserId(long userId)
        {
            return await _distributedCache.GetOrSet(CacheKeys.User(userId), () =>
            {
                return _mediator.Send(new GetUserByIdQuery(userId));
            });
        }

        public async Task<UserTokenDto> GetUserByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hash.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserByToken(string jwtToken)
        {
            var hashJwtToken = Sha256Hash.Hash(jwtToken);

            return await _distributedCache.GetOrSet(CacheKeys.UserToken(hashJwtToken), () =>
            {
                return _mediator.Send(new GetUserByJwtTokenQuery(hashJwtToken));
            });
        }
    }
}
