namespace Crm.Domain.Shared
{
    /// <summary>
    /// BaseEntity define for properties need in all Entities
    /// this project need Id and CreationDate for all Entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// define constructor and set CreationDate to datetime now
        /// </summary>
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// property Id and define private set that cant change in another class
        /// and just readonly
        /// </summary>
        public long Id { get; private set; }
        /// <summary>
        /// property CreationDate and define private set that just readonly
        /// </summary>
        public DateTime CreationDate { get; private set; }
    }
}
