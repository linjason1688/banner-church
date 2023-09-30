using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryRespUserConfig : IEntityTypeConfiguration<MinistryRespUser>
    {
        public void Configure(EntityTypeBuilder<MinistryRespUser> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MinistryRespUser");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.MinistryRespId).IsUnicode().HasMaxLength(20);
            builder.Property(e => e.MinistryRespUserStatus).IsUnicode().HasMaxLength(20);
            builder.Property(e => e.UserId).HasMaxLength(20);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");




        }
    }
}
