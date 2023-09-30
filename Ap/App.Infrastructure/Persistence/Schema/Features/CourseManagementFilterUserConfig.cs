using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementFilterUserConfig : IEntityTypeConfiguration<CourseManagementFilterUser>
    {
        public void Configure(EntityTypeBuilder<CourseManagementFilterUser> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementFilterUser");


            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Id).HasMaxLength(200);
            builder.Property(e => e.CourseManagementFilterId).HasMaxLength(200);
            builder.Property(e => e.UserId).HasMaxLength(200);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseManagementFilterUserNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementFilterUserStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementFilterUserNo);
            builder.Property(e => e.CourseManagementFilterUserStatus);
            */





        }
    }
}
