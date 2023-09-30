
using System.ComponentModel;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionnaireDetailConfig : IEntityTypeConfiguration<QuestionnaireDetail>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<QuestionnaireDetail> builder)
        {
            // table name mapping
            builder.ToTable(nameof(QuestionnaireDetail));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            // ### columns

             builder.Property(e => e.Id)
                .UseIdentityColumn();


            builder.Property(e => e.QuestionnaireId).HasMaxLength(32);
            builder.Property(e => e.UpperQuestionnaireDetailId).HasMaxLength(32);
            builder.Property(e => e.QuestionnaireDetailType).HasMaxLength(32);
            builder.Property(e => e.ComponentType).HasMaxLength(32);
            builder.Property(e => e.Sequence).HasMaxLength(32);
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(500);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(500);

            /*
            builder.Property(e => e.PastoralId).HasMaxLength(32);
            builder.Property(e => e.OrganizationId).HasMaxLength(32);
            builder.Property(e => e.CourseManagementTypeId).HasMaxLength(32);
            builder.Property(e => e.CourseManagementName).HasMaxLength(200);
            builder.Property(e => e.CourseYear).HasMaxLength(20);
            builder.Property(e => e.CourseSeason).HasMaxLength(20);
            builder.Property(e => e.CourseClassNum).HasMaxLength(32);
            builder.Property(e => e.CourseManagementNo).HasMaxLength(32);
            builder.Property(e => e.CourseHomeworkDate).HasMaxLength(20);
            */




            builder.Property(e => e.StatusCd).HasDefaultValue("1");




            // ### index
            //  builder.HasIndex(
            //      e => new
            //      {
            //      }
            //  );

            // ### ForeignKeys



        }
    }
}




