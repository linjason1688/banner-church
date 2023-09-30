using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBankAccountConfig : IEntityTypeConfiguration<UserBankAccount>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserBankAccount> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UserBankAccount));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

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
