using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class MinistryMeetingUserConfig : IEntityTypeConfiguration<MinistryMeetingUser>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<MinistryMeetingUser> builder)
        {
            // table name mapping
            builder.ToTable(nameof(MinistryMeetingUser));

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
            builder.Property(e => e.MinistryMeetingId).HasMaxLength(36);
            builder.Property(e => e.UserId).HasMaxLength(36);
            builder.Property(e => e.MeetAttendanceType).HasMaxLength(36);

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
