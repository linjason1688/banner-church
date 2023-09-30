using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionnaireSatisfyUserConfig : IEntityTypeConfiguration<QuestionnaireSatisfyUser>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<QuestionnaireSatisfyUser> builder)
        {
            // table name mapping
            builder.ToTable(nameof(QuestionnaireSatisfyUser));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            // ### columns
            builder.ToTable("QuestionnaireSatisfyUser");
            builder.Property(e => e.Id)
             .UseIdentityColumn();

    
            builder.Property(e => e.QuestionnaireId).HasMaxLength(30);
            builder.Property(e => e.UserId).HasMaxLength(30);
            builder.Property(e => e.QuestionnaireWriteType).HasMaxLength(30);
            builder.Property(e => e.QuestionnaireGoArea).HasMaxLength(50);
            builder.Property(e => e.Satisfaction).HasMaxLength(30);
            builder.Property(e => e.Evaluation).HasMaxLength(30);
            builder.Property(e => e.WriteQuestionnaireDate).HasMaxLength(30);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");




            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            // builder.Property(e => e.Id)
            //    .UseIdentityColumn();

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
