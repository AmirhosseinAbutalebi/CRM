using MediatR;

namespace Crm.Application.User.AddToken
{
    public class AddTokenCommand : IRequest
    {
        public AddTokenCommand(long usersId, string hashJwtToken, string hashRefreshToken,
            DateTime expireToken, DateTime expireRefreshToken, string device)
        {
            UsersId = usersId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            ExpireToken = expireToken;
            ExpireRefreshToken = expireRefreshToken;
            Device = device;
        }

        public long UsersId { get; private set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime ExpireToken { get; private set; }
        public DateTime ExpireRefreshToken { get; private set; }
        public string Device { get; private set; }
    }
}
