using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class UserQuestionnaireConfig : IEntityTypeConfiguration<UserQuestionnaire>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserQuestionnaire> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UserQuestionnaire));

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
