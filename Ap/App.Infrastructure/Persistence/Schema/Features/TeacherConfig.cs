using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("Teacher");
            builder.Property(e => e.UserId).HasMaxLength(32);
            builder.Property(e => e.OrganizationId).HasMaxLength(32);
            builder.Property(e => e.TeacherName).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.ContactPhone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.ContactCellPhone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.ContactEmail).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Comment).IsUnicode().HasMaxLength(200);



            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.TeacherNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.TeacherStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.TeacherNo);
            builder.Property(e => e.TeacherStatus);
            */





        }
    }
}
