using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementFilterCourseConfig : IEntityTypeConfiguration<CourseManagementFilterCourse>
    {
        public void Configure(EntityTypeBuilder<CourseManagementFilterCourse> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementFilterCourse");


            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Id).HasMaxLength(200);
            builder.Property(e => e.CourseManagementFilterId).HasMaxLength(32);
            builder.Property(e => e.CourseManagementId).HasMaxLength(32);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseManagementFilterCourseNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementFilterCourseStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementFilterCourseNo);
            builder.Property(e => e.CourseManagementFilterCourseStatus);
            */





        }
    }
}
