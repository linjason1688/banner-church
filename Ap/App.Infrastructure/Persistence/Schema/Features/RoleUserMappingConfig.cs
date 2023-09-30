using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleUserMappingConfig : IEntityTypeConfiguration<RoleUserMapping>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<RoleUserMapping> builder)
        {
            // table name mapping
            builder.ToTable(nameof(RoleUserMapping));

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
            builder.Property(e => e.UserId);
            builder.Property(e => e.RoleId);

            #endregion

            // index
            builder.HasIndex(
                e => new
                {
                    e.UserId,
                    e.RoleId
                }
            );

            #region ForeignKeys

            #endregion
        }
    }
}
