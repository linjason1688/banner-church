using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseManagementFilterPastoralConfig : IEntityTypeConfiguration<CourseManagementFilterPastoral>
    {
        public void Configure(EntityTypeBuilder<CourseManagementFilterPastoral> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseManagementFilterPastoral");


            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Id).HasMaxLength(200);
            builder.Property(e => e.CourseManagementFilterId).HasMaxLength(200);
            builder.Property(e => e.PastoralId).HasMaxLength(200);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseManagementFilterPastoralNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseManagementFilterPastoralStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseManagementFilterPastoralNo);
            builder.Property(e => e.CourseManagementFilterPastoralStatus);
            */





        }
    }
}
