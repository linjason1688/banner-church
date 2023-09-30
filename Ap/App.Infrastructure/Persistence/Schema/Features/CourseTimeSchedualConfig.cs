using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseTimeScheduleConfig : IEntityTypeConfiguration<CourseTimeSchedule>
    {
        public void Configure(EntityTypeBuilder<CourseTimeSchedule> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseTimeSchedule");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseId).HasMaxLength(32);
            builder.Property(e => e.ScheduleNo).HasMaxLength(32);
            builder.Property(e => e.ClassDay).HasMaxLength(32);
            builder.Property(e => e.ClassTimeS).HasMaxLength(32);
            builder.Property(e => e.ClassTimeE).HasMaxLength(32);
            builder.Property(e => e.Place).HasMaxLength(32);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseTimeScheduleNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseTimeScheduleStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseTimeScheduleNo);
            builder.Property(e => e.CourseTimeScheduleStatus);
            */





        }
    }
}
