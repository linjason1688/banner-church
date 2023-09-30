using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePrivilegeMappingConfig : IEntityTypeConfiguration<RolePrivilegeMapping>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<RolePrivilegeMapping> builder)
        {
            // table name mapping
            builder.ToTable(nameof(RolePrivilegeMapping));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            #region columns

            // builder.Property(e => e.Id)
            //    .IsUnicode(false);

            builder.Property(e => e.Id);
            builder.Property(e => e.RoleId);
            builder.Property(e => e.PrivilegeId);
            builder.Property(e => e.Enable);

            builder.Property(e => e.ViewGranted);

            builder.Property(e => e.ModifyGranted);

            builder.Property(e => e.DeleteGranted);

            builder.Property(e => e.UploadGranted);

            builder.Property(e => e.DownloadGranted);

            #endregion

            // index
            builder.HasIndex(
                e => new
                {
                    e.RoleId,
                    e.PrivilegeId
                }
            );

            #region ForeignKeys

            #endregion
        }
    }
}
