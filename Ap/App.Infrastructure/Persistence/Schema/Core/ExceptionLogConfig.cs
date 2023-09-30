using App.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Core
{
    /// <summary>
    /// </summary>
    public class ExceptionLogConfig : IEntityTypeConfiguration<ExceptionLog>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            // table name mapping
            // builder.ToTable(nameof(ExceptionLog));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            #region columns

            builder.Property(e => e.Id)
               .UseIdentityColumn();

            builder.Property(e => e.HandledId);

            builder.Property(e => e.MachineName)
               .HasMaxLength(64)
               .IsUnicode(false);

            builder.Property(e => e.Message)
               .HasMaxLength(1024)
               .IsUnicode();

            builder.Property(e => e.Source)
               .HasMaxLength(1024)
               .IsUnicode();

            builder.Property(e => e.StackTrace)
               .IsUnicode();

            builder.Property(e => e.ExtraData)
               .IsUnicode();

            #endregion

            // index
            builder.HasIndex(
                e => new
                {
                    e.MachineName
                }
            );

            #region ForeignKeys

            #endregion
        }
    }
}
