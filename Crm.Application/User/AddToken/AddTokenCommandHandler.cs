using Crm.Domain.UserAgg.Repository;
using MediatR;

namespace Crm.Application.User.AddToken
{
    internal class AddTokenCommandHandler : IRequestHandler<AddTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UsersId);
            if (user == null)
                throw new InvalidDataException("چنین کاربری وجود ندارد");

            user.AddToken(request.HashJwtToken, request.HashRefreshToken, request.ExpireToken,
                request.ExpireRefreshToken, request.Device);

            _userRepository.Update(user);
            await _userRepository.Save();
        }
    }
}
