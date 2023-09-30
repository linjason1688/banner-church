using App.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Core
{
    /// <summary>
    /// </summary>
    public class ApiAuditLogConfig : IEntityTypeConfiguration<ApiAuditLog>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApiAuditLog> builder)
        {
            // table name mapping
            // builder.ToTable(nameof(ApiAuditLog));

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

            builder.Property(e => e.Account)
               .HasMaxLength(64)
               .IsUnicode();

            builder.Property(e => e.Name)
               .HasMaxLength(32)
               .IsUnicode();

            builder.Property(e => e.SourceIp)
               .HasMaxLength(128)
               .IsUnicode(false);

            builder.Property(e => e.HttpMethod)
               .HasMaxLength(16)
               .IsUnicode(false);

            builder.Property(e => e.RequestPath)
               .HasMaxLength(512)
               .IsUnicode(false);

            builder.Property(e => e.RequestQueryString)
               .IsUnicode();

            builder.Property(e => e.RequestHeaders)
               .IsUnicode();

            builder.Property(e => e.RequestBody)
               .IsUnicode();

            builder.Property(e => e.ResponseBody)
               .IsUnicode();

            #endregion

            // index
            builder.HasIndex(
                e => new
                {
                    e.HandledId,
                    e.Account,
                    e.Name,
                    e.HttpMethod,
                    e.SourceIp,
                    e.RequestPath,
                    e.ResponseStatusCode
                }
            );

            #region ForeignKeys

            #endregion
        }
    }
}
