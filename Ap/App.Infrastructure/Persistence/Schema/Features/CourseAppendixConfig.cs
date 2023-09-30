using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseAppendixConfig : IEntityTypeConfiguration<CourseAppendix>
    {
        public void Configure(EntityTypeBuilder<CourseAppendix> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("CourseAppendix");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseId).HasMaxLength(32);
            builder.Property(e => e.AppendixType).HasMaxLength(32);
            builder.Property(e => e.Path).IsUnicode().HasMaxLength(200);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");


            //builder.Property(e => e.CourseAppendixNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseAppendixStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseAppendixNo);
            builder.Property(e => e.CourseAppendixStatus);
            */





        }
    }
}
