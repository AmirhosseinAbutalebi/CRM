using Crm.Domain.Shared;
using Crm.Domain.UserAgg.Enums;

namespace Crm.Domain.UserAgg
{
    /// <summary>
    /// this class is root and for define entity Users
    /// we dont have essential method and this project is basic
    /// then we dont have mehtod in this domain
    /// </summary>
    public class Users : AggregateRoot
    {
        /// <summary>
        /// need to define constructor for Entity framework
        /// </summary>
        private Users()
        {

        }
        /// <summary>
        /// property UserName for username of person and just readonly (private set)
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// property Password for Password of person and just readonly (private set)
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// property FirstName for FirstName of person and just readonly (private set)
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// property LastName for LastName of person and just readonly (private set)
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// property Role for check user is teacher or student and just readonly (private set)
        /// </summary>
        public LevelUser Role { get; private set; }

    }
}
