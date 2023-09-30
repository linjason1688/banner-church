using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementFilterConfig : IEntityTypeConfiguration<CourseManagementFilter>
    {
        public void Configure(EntityTypeBuilder<CourseManagementFilter> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementFilter");


            builder.Property(e => e.Id).UseIdentityColumn();

          
            builder.Property(e => e.CourseManagementId).HasMaxLength(32);
            builder.Property(e => e.OrganizationId).HasMaxLength(32);
            builder.Property(e => e.CourseSex).HasMaxLength(32);
            builder.Property(e => e.AgeUp).HasMaxLength(32);
            builder.Property(e => e.AgeDown).HasMaxLength(32);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.CourseManagementFilterNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementFilterStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementFilterNo);
            builder.Property(e => e.CourseManagementFilterStatus);
            */





        }
    }
}
