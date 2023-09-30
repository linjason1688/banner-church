using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementConfig : IEntityTypeConfiguration<CourseManagement>
    {
        public void Configure(EntityTypeBuilder<CourseManagement> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagement");


            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseManagementTypeId).HasMaxLength(32);

            builder.Property(e => e.OrganizationId).HasMaxLength(32);

            builder.Property(e => e.Title).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.CourseManagementStatus).HasMaxLength(20);

            builder.Property(e => e.CourseManagementNo).HasMaxLength(20);
            builder.Property(e => e.BasicQualification).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.GraduationQualification).IsUnicode().HasMaxLength(200);

            builder.Property(e => e.CourseType).HasMaxLength(20);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.CourseManagementNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementNo);
            builder.Property(e => e.CourseManagementStatus);
            */





        }
    }
}
