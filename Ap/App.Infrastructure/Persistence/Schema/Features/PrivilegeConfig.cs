using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Infrastructure.Persistence.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivilegeConfig : IEntityTypeConfiguration<Privilege>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            // table name mapping
            builder.ToTable(nameof(Privilege));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            #region columns

            builder.Property(e => e.Id);

            // 
            builder.Property(e => e.FunctionId)
               .HasMaxLength(20)
               .IsUnicode();

            builder.Property(e => e.ParentFunctionId)
               .HasMaxLength(20)
               .IsUnicode();

            builder.Property(e => e.Name)
               .HasMaxLength(64)
               .IsUnicode();

            builder.Property(e => e.Sort);

            builder.Property(e => e.LinkType)
               .HasEnumStringConversion();

            builder.Property(e => e.QueryParams)
               .HasMaxLength(2048)
               .IsUnicode();

            builder.Property(e => e.Icon)
               .HasMaxLength(64);

            builder.Property(e => e.Comment)
               .ConfigCommentColumn();

            #endregion

            // index
            builder.HasIndex(
                    e => new
                    {
                        e.FunctionId
                    }
                )
               .IsUnique();

            builder.HasIndex(
                e => new
                {
                    e.ParentFunctionId,
                    e.LinkType
                }
            );

            #region ForeignKeys

            #endregion
        }
    }
}
