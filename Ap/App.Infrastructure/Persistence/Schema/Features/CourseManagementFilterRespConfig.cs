using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementFilterRespConfig : IEntityTypeConfiguration<CourseManagementFilterResp>
    {
        public void Configure(EntityTypeBuilder<CourseManagementFilterResp> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementFilterResp");


            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Id).HasMaxLength(200);
            builder.Property(e => e.CourseManagementFilterId).HasMaxLength(200);
            builder.Property(e => e.MinistryRespId).HasMaxLength(200);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseManagementFilterRespNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementFilterRespStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementFilterRespNo);
            builder.Property(e => e.CourseManagementFilterRespStatus);
            */





        }
    }
}
