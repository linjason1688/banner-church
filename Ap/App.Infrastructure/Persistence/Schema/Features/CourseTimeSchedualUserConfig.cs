using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseTimeScheduleUserConfig : IEntityTypeConfiguration<CourseTimeScheduleUser>
    {
        public void Configure(EntityTypeBuilder<CourseTimeScheduleUser> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseTimeScheduleUser");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseTimeScheduleId).HasMaxLength(32);
            builder.Property(e => e.ScheduleNo).HasMaxLength(32);
            builder.Property(e => e.UserId).HasMaxLength(32);
            builder.Property(e => e.AttendanceType).HasMaxLength(32);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");
        }
    }
}
