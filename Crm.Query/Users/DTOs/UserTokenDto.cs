namespace Crm.Query.Users.DTOs
{
    public class UserTokenDto
    {
        public long Id { get; set; }
        public long UsersId { get; set; }
        public string HashJwtToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime ExpireToken { get; set; }
        public DateTime ExpireRefreshToken { get; set; }
        public string Device { get; set; }
    }
}
