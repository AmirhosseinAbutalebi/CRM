using Crm.Domain.TicketAgg;
using Crm.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
namespace Crm.Infrastructure.Persistent.Ef
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrmDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
    }
}
