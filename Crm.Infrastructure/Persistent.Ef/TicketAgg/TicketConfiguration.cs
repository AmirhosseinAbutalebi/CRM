using Crm.Domain.TicketAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infrastructure.Persistent.Ef.TicketAgg
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.ToTable("Tickets", "ticket");
            builder.OwnsMany(b=> b.Items, option =>
            {
                option.ToTable("TicketDetails", "ticket");
            });
        }
    }
}
