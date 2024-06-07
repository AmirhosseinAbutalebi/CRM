using Crm.Domain.UserAgg.Repository;
using MediatR;

namespace Crm.Application.User.RemoveToken
{
    internal class RemoveTokenCommandHandler : IRequestHandler<RemoveTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                throw new InvalidDataException("چنین کاربری وجود ندارد");

            user.removeToken(request.TokenId);
            await _userRepository.Save();
        }
    }
}
