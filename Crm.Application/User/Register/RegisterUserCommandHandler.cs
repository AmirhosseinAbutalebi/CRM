using Crm.Application.Shared;
using Crm.Domain.UserAgg;
using Crm.Domain.UserAgg.Repository;
using MediatR;

namespace Crm.Application.User.Register
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var password = Sha256Hash.Hash(request.Password);
            var user = new Users(request.UserName, password, request.FirstName, request.LastName, request.Role);

            _userRepository.Add(user);
            await _userRepository.Save();

        }
    }
}
