using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("Course");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CourseManagementId).HasMaxLength(200);
            builder.Property(e => e.OrganizationId).HasMaxLength(200);
            builder.Property(e => e.QuestionnaireId).HasMaxLength(200);
            builder.Property(e => e.Year).HasMaxLength(32);

            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.ClassNum).HasMaxLength(32);
            builder.Property(e => e.Season).HasMaxLength(32);
            builder.Property(e => e.OpenDateS).HasMaxLength(32);
            builder.Property(e => e.OpenDateE).HasMaxLength(32);
            builder.Property(e => e.SignUpDateS).HasMaxLength(32);
            builder.Property(e => e.SignUpDateE).HasMaxLength(32);

            builder.Property(e => e.CounterSignUpDateS).HasMaxLength(32);
            builder.Property(e => e.CounterSignUpDateE).HasMaxLength(32);
            builder.Property(e => e.DiscountSignUpDate).HasMaxLength(32);
            builder.Property(e => e.CourseSignUpType).HasMaxLength(32);
            builder.Property(e => e.WishCount).HasMaxLength(32);
            builder.Property(e => e.NeedRecommend).HasMaxLength(32);
            builder.Property(e => e.AcceptNewMember).HasMaxLength(32);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.CourseCount).HasMaxLength(32);
            builder.Property(e => e.Quota).HasMaxLength(32);

            builder.Property(e => e.GraduationType).HasMaxLength(32);

            builder.Property(e => e.SpecialRequirement).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.BasicQualification).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.GraduationQualification).IsUnicode().HasMaxLength(200);

           
        
            builder.Property(e => e.CourseContext).IsUnicode().HasMaxLength(500);

            builder.Property(e => e.CourseNoticeDesc).IsUnicode().HasMaxLength(500);
            builder.Property(e => e.CourseRefundDesc).IsUnicode().HasMaxLength(500);
           
            builder.Property(e => e.HomeworkDate).HasMaxLength(32);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            builder.Property(e => e.CourseManagementFilterId).HasMaxLength(200);


            //builder.Property(e => e.CourseNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.CourseStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.CourseNo);
            builder.Property(e => e.CourseStatus);
            */





        }
    }
}
