namespace Crm.Domain.UserAgg.Repository
{
    /// <summary>
    /// in this interface we define method needed in UserRepository
    /// then use in Application layer for commands
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// method add for add user to database
        /// this project we dont need this method but 
        /// we define it
        /// </summary>
        /// <param name="user">param user with type Users</param>
        void Add(Users user);
        /// <summary>
        /// method update for update user in database 
        /// this project we dont need this method but 
        /// we define it
        /// </summary>
        /// <param name="user">param user with type Users</param>
        void Update(Users user);
        /// <summary>
        /// method delete for delete user with id from database
        /// and this method dont use in projcet too
        /// </summary>
        /// <param name="user">Users user for user that we wanna deleted</param>
        void Delete(Users user);
        /// <summary>
        /// this method for save changes in database
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChanges();
        /// <summary>
        /// mehtod GetById for get user with id from database
        /// </summary>
        /// <param name="id">long id for get user that we wanna fetch and use in program</param>
        /// <returns>Task of Users</returns>
        Task<Users> GetById(long id);
        /// <summary>
        /// mehtod GetByUserName for get user with username from database
        /// </summary>
        /// <param name="username">string username for get user that we wanna fetch and use in program</param>
        /// <returns>Task of Users</returns>
        Task<Users> GetByUserName(string username);
        /// <summary>
        /// mehtod check user exists in database or not
        /// </summary>
        /// <param name="username">string username for check this username exists or not</param>
        /// <returns>true for exist user in databse and false for dosen't exist use in database </returns>
        bool UserExists(string username);
    }
}
