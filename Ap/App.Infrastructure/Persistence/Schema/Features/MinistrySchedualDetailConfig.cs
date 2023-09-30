using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryScheduleDetailConfig : IEntityTypeConfiguration<MinistryScheduleDetail>
    {
        public void Configure(EntityTypeBuilder<MinistryScheduleDetail> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MinistryScheduleDetail");
            builder.Property(e => e.Id).UseIdentityColumn();          
            builder.Property(e => e.MinistryScheduleId).HasMaxLength(36);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(50);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MinistryScheduleDetailNo);
            builder.Property(e => e.MinistryScheduleDetailStatus);
            */





        }
    }
}
