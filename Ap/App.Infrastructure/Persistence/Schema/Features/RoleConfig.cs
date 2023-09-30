using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // table name mapping
            builder.ToTable(nameof(Role));

            // primary key
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            #region columns

            builder.Property(e => e.Id);

            builder.Property(e => e.Name)
               .HasMaxLength(63);

            #endregion

            // index
            // builder.HasIndex(
            //     e => new
            //     {
            //     }
            // );

            #region ForeignKeys


            #endregion
        }
    }
}
