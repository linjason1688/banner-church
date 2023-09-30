using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryDefConfig : IEntityTypeConfiguration<MinistryDef>
    {
        public void Configure(EntityTypeBuilder<MinistryDef> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MinistryDef");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MinistryDefNo);
            builder.Property(e => e.MinistryDefStatus);
            builder.Property(e => e.MinistryDefType).HasDefaultValue("0");
            //builder.Property(e => e.MinistryDefType).HasDefaultValue("0");


            builder.Property(e => e.StatusCd).HasDefaultValue("1");



        }
    }
}
