using Crm.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users", "user");
            builder.OwnsMany(b => b.Tokens, option =>
            {
                option.ToTable("UserTokens", "user");

                option.HasKey(b=> b.Id);

                option.Property(b => b.HashJwtToken)
                .IsRequired()
                .HasMaxLength(250);

                option.Property(b => b.HashRefreshToken)
                .IsRequired()
                .HasMaxLength(250);

                option.Property(b => b.Device)
                .IsRequired()
                .HasMaxLength(100);
            });
        }
    }
}
