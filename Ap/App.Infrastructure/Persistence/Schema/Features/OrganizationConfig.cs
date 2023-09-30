using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace App.Infrastructure.Persistence.Schema.Features
{
    public class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("Organization");
            builder.Property(e => e.Id).UseIdentityColumn();

            //builder.Property(e => e.OrganizationId).HasMaxLength(255);

            builder.Property(e => e.DeptId).HasMaxLength(255);

            builder.Property(e => e.UpperOrganizationId).HasMaxLength(255);


            //builder.Property(e => e.PastoralId).HasMaxLength(30);
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.PastorName).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.PastorId).HasMaxLength(255);
            builder.Property(e => e.Pastor).IsUnicode().HasMaxLength(50);

            builder.Property(e => e.Pastorphone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Phone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Fax).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Email).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Site).IsUnicode().HasMaxLength(200);

            builder.Property(e => e.Zip).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Address).IsUnicode().HasMaxLength(255);

            builder.Property(e => e.InvoiceIdentifier).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.InvoiceTitle).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.IsInvoiceTitle).IsUnicode().HasMaxLength(50);

            builder.Property(e => e.OrgStatus).HasDefaultValue("1");
            builder.Property(e => e.OrgStatus).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.OrgStatus).HasDefaultValue("1");



            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            builder.Property(e => e.LineToken).HasMaxLength(200);

            ////builder.Property(e => e.Comment).HasMaxLength(255);

            ////builder.Property(e => e.DateCreate).HasColumnType("datetime");

            ////builder.Property(e => e.DateUpdate).HasColumnType("datetime");

            //builder.Property(e => e.Email).HasMaxLength(255);

            //builder.Property(e => e.Fax)
            //   .HasMaxLength(20)
            //.IsUnicode(false);

            //builder.Property(e => e.InvoiceIdentifier)
            //   .HasMaxLength(20)
            //.IsUnicode(false);

            //builder.Property(e => e.InvoiceTitle).HasMaxLength(255);

            //builder.Property(e => e.Name)
            //   .IsRequired()
            //.HasMaxLength(255);

            //builder.Property(e => e.Oid).HasColumnName("OId");

            //builder.Property(e => e.Pastor)
            //   .IsRequired()
            //.HasMaxLength(50);

            //builder.Property(e => e.PastorName).HasMaxLength(50);

            //builder.Property(e => e.Pastorphone)
            //   .HasMaxLength(20)
            //   .IsUnicode(false);

            //builder.Property(e => e.Phone)
            //   .HasMaxLength(20)
            //   .IsUnicode(false);

            //builder.Property(e => e.Site).HasMaxLength(255);

            ////builder.Property(e => e.StatusCd)
            ////   .HasMaxLength(20)
            ////   .IsUnicode(false);

            ////builder.Property(e => e.UserCreate).HasMaxLength(255);

            ////builder.Property(e => e.UserUpdate).HasMaxLength(255);

            //builder.Property(e => e.Zip)
            //   .HasMaxLength(20)
            //   .IsUnicode(false);





            #region fks



            #endregion
        }
    }
}
