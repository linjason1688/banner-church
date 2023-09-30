using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseTimeScheduleTeacherConfig : IEntityTypeConfiguration<CourseTimeScheduleTeacher>
    {
        public void Configure(EntityTypeBuilder<CourseTimeScheduleTeacher> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseTimeScheduleTeacher");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseTimeScheduleId).HasMaxLength(32);
            builder.Property(e => e.ScheduleNo).HasMaxLength(32);
            builder.Property(e => e.TeacherId).HasMaxLength(32);

            builder.Property(e => e.AttendanceType).HasMaxLength(32);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");


            //builder.Property(e => e.CourseTimeScheduleTeacherNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseTimeScheduleTeacherStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseTimeScheduleTeacherNo);
            builder.Property(e => e.CourseTimeScheduleTeacherStatus);
            */





        }
    }
}
