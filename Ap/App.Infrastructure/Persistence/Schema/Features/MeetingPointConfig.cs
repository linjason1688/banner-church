using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class MeetingPointConfig : IEntityTypeConfiguration<MeetingPoint>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<MeetingPoint> builder)
        {
            // table name mapping
            builder.ToTable(nameof(MeetingPoint));

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

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Memo).HasMaxLength(200);
            builder.Property(e => e.Phone).HasMaxLength(30);
            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.Name).HasMaxLength(300);
            builder.Property(e => e.OrganizationId).HasMaxLength(36);
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
