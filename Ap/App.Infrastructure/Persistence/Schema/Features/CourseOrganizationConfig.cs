using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseOrganizationConfig : IEntityTypeConfiguration<CourseOrganization>
    {
        public void Configure(EntityTypeBuilder<CourseOrganization> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseOrganization");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseId).HasMaxLength(32);

            builder.Property(e => e.OrganizationId).HasMaxLength(32);



            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CourseOrganizationNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseOrganizationStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseOrganizationNo);
            builder.Property(e => e.CourseOrganizationStatus);
            */





        }
    }
}
