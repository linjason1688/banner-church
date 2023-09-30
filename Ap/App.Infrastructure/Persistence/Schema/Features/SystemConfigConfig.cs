using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    public class SystemConfigConfig : IEntityTypeConfiguration<SystemConfig>
    {
        public void Configure(EntityTypeBuilder<SystemConfig> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("SystemConfig");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Type);
            builder.Property(e => e.Name);
            builder.Property(e => e.Value);
           
        }
    }
}
