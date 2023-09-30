using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// </summary>
    public class UploadFileSchema : IEntityTypeConfiguration<UploadFile>
    {
        public void Configure(EntityTypeBuilder<UploadFile> builder)
        {
            // table name mapping
            builder.ToTable(nameof(UploadFile));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            #region columns

            builder.Property(e => e.FileKey);

            builder.Property(e => e.OwnerEntity)
               .HasMaxLength(32)
               .IsUnicode(false);

            builder.Property(e => e.Filename)
               .HasMaxLength(64)
               .IsUnicode();

            builder.Property(e => e.FileExtension)
               .HasMaxLength(16)
               .IsUnicode();

            builder.Property(e => e.RelativeFilepath)
               .HasMaxLength(256)
               .IsUnicode();

            builder.Property(e => e.FileSize);

            builder.Property(e => e.Bound);

            #endregion

            // index
            builder.HasIndex(
                    e => new
                    {
                        e.FileKey
                    }
                )
               .IsUnique();

            #region ForeginKeys

            #endregion
        }
    }
}
