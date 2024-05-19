using Crm.Domain.TicketAgg;
using Crm.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
namespace Crm.Infrastructure.Persistent.Ef
{
    /// <summary>
    /// class for database and set table and connection and ...
    /// </summary>
    public class CrmDbContext : DbContext
    {
        /// <summary>
        /// constructor CrmDbContext 
        /// </summary>
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// create table user
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// create table tickets
        /// </summary>
        public DbSet<Tickets> Tickets { get; set; }
        /// <summary>
        /// create table ticketdetail
        /// </summary>
        public DbSet<Domain.TicketDetailAgg.TicketDetail> TicketDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
