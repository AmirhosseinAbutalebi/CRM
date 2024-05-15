using Crm.Domain.UserAgg.Enums;

namespace Crm.Query.Users.DTOs
{
    /// <summary>
    /// define dto for use in query
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// long id 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// string username
        /// </summary>
        public string UserName { get;  set; }
        /// <summary>
        /// string password
        /// </summary>
        public string Password { get;  set; }
        /// <summary>
        /// string firstname
        /// </summary>
        public string FirstName { get;  set; }
        /// <summary>
        /// string lastname
        /// </summary>
        public string LastName { get;  set; }
        /// <summary>
        /// enum leveluser for show user is teacher or student
        /// </summary>
        public LevelUser Role { get;  set; }
    }
}
