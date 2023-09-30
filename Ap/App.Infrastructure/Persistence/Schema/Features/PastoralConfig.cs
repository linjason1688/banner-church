using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class PastoralConfig : IEntityTypeConfiguration<Pastoral>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Pastoral> builder)
        {
            // table name mapping
            builder.ToTable(nameof(Pastoral));

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
            builder.Property(e => e.DeptId).HasMaxLength(255);
            builder.Property(e => e.UpperPastoralId).HasMaxLength(36);
            builder.Property(e => e.UpperPastoralId);
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(20);
            builder.Property(e => e.Title).IsUnicode().HasMaxLength(20);

            builder.Property(e => e.GroupNo).HasMaxLength(8);
            builder.Property(e => e.LeaderId).HasMaxLength(20);
            builder.Property(e => e.LeaderIdNumber);
            builder.Property(e => e.Leader2Id).HasMaxLength(20);
            builder.Property(e => e.Leader2IdNumber);
            builder.Property(e => e.Leader3Id).HasMaxLength(20);
            builder.Property(e => e.Leader3IdNumber);
            builder.Property(e => e.SupervisorId).HasMaxLength(20);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            builder.Property(e => e.LineToken).HasMaxLength(200);

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
