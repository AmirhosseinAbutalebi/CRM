using Crm.Domain.Shared;

namespace Crm.Domain.UserAgg
{
    public class UserToken:BaseEntity
    {
        private UserToken()
        {
            
        }
        public UserToken(string hashJwtToken, string hashRefreshToken, DateTime expireToken, DateTime expireRefreshToken, string device)
        {
            Guard(hashJwtToken, hashRefreshToken, expireToken, expireRefreshToken, device);
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            ExpireToken = expireToken;
            ExpireRefreshToken = expireRefreshToken;
            Device = device;
        }

        public long UsersId { get; internal set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime ExpireToken { get; private set; }
        public DateTime ExpireRefreshToken { get; private set; }
        public string Device { get; private set; }

        public void Guard(string hashJwtToken, string hashRefreshToken, DateTime expireToken, DateTime expireRefreshToken, string device)
        {
            if (hashJwtToken == null)
                throw new InvalidDataException("jwt token not be null");

            if (hashRefreshToken == null)
                throw new InvalidDataException("refresh token not be null");

            if (expireToken < DateTime.Now)
                throw new InvalidDataException("Invalid Token ExpireDate");

            if (expireRefreshToken < expireToken)
                throw new InvalidDataException("Invalid RefreshToken ExpireDate");
        }
    }
}
