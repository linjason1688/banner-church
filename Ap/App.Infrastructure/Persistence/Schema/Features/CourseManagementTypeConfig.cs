using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementTypeConfig : IEntityTypeConfiguration<CourseManagementType>
    {
        public void Configure(EntityTypeBuilder<CourseManagementType> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementType");


            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseManagementTypeNo).HasMaxLength(200);
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Remark).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.CourseManagementTypeNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementTypeStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementTypeNo);
            builder.Property(e => e.CourseManagementTypeStatus);
            */





        }
    }
}
