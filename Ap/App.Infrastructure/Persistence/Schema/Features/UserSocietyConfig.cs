using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSocietyConfig : IEntityTypeConfiguration<UserSociety>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserSociety> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UserSociety));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.Property(e => e.Id)
                         .UseIdentityColumn();

            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            builder.Property(e => e.UserId).HasMaxLength(36);
            builder.Property(e => e.Name).HasMaxLength(30);

            // ### columns

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
