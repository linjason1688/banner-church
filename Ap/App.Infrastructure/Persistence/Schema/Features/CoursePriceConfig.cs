using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CoursePriceConfig : IEntityTypeConfiguration<CoursePrice>
    {
        public void Configure(EntityTypeBuilder<CoursePrice> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CoursePrice");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseId).HasMaxLength(32);
            builder.Property(e => e.PriceName).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Price).HasMaxLength(32);
            builder.Property(e => e.IsPublic).HasMaxLength(32);
            builder.Property(e => e.IsDueDate).HasMaxLength(32);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.CoursePriceNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CoursePriceStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CoursePriceNo);
            builder.Property(e => e.CoursePriceStatus);
            */





        }
    }
}
