using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace App.Infrastructure.Persistence.Schema.Features
{
    public class OrganizationUserConfig : IEntityTypeConfiguration<OrganizationUser>
    {
        public void Configure(EntityTypeBuilder<OrganizationUser> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("OrganizationUser");
            builder.Property(e => e.Id).UseIdentityColumn();

            //builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserId);
            builder.Property(e => e.OrganizationId).HasMaxLength(255);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");


            #region fks



            #endregion
        }
    }
}
