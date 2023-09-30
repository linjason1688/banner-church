using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryRespConfig : IEntityTypeConfiguration<MinistryResp>
    {
        public void Configure(EntityTypeBuilder<MinistryResp> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MinistryResp");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.MinistryId).HasMaxLength(32);
            builder.Property(e => e.Seq).HasMaxLength(32);
            builder.Property(e => e.ManageType).HasMaxLength(32);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");




        }
    }
}
