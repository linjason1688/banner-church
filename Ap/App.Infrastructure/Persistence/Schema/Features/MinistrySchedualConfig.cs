using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryScheduleConfig : IEntityTypeConfiguration<MinistrySchedule>
    {
        public void Configure(EntityTypeBuilder<MinistrySchedule> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MinistrySchedule");
            builder.Property(e => e.Id).UseIdentityColumn();          
            builder.Property(e => e.MinistryId).HasMaxLength(36);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.CycleType).HasMaxLength(20);
            builder.Property(e => e.RepeatTime).HasMaxLength(20);
            builder.Property(e => e.RepeatTimeUnit).HasMaxLength(20);
            builder.Property(e => e.EndDateType).HasMaxLength(20);

            builder.Property(e => e.EndDate).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.RepeaTimes).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");



            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MinistryScheduleNo);
            builder.Property(e => e.MinistryScheduleStatus);
            */





        }
    }
}
