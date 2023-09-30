using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class UserContactConfig : IEntityTypeConfiguration<UserContact>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UserContact));

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
