using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class PastoralMeetingConfig : IEntityTypeConfiguration<PastoralMeeting>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PastoralMeeting> builder)
        {
            // table name mapping
            builder.ToTable(nameof(PastoralMeeting));

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
            
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.PastoralId).HasMaxLength(36);
            builder.Property(e => e.MeetingDayOfWeek).HasMaxLength(36);
            builder.Property(e => e.MeetingTime).HasMaxLength(36);
            builder.Property(e => e.MeetingAddress).HasMaxLength(36);
            builder.Property(e => e.MeetingDay).HasMaxLength(36);
            builder.Property(e => e.IsExp).HasMaxLength(36);
            builder.Property(e => e.IsSearchable).HasMaxLength(36);
            builder.Property(e => e.MeetType).HasMaxLength(36);
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
