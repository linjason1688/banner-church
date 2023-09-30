using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPastoralCareConfig : IEntityTypeConfiguration<UserPastoralCare>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserPastoralCare> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UserPastoralCare));

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

            builder.Property(e => e.UserId).HasMaxLength(32);
            builder.Property(e => e.CareType).HasMaxLength(20);
            builder.Property(e => e.PastoralTitle).HasMaxLength(50);

            builder.Property(e => e.NewArea).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.OldArea).IsUnicode().HasMaxLength(200);




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
