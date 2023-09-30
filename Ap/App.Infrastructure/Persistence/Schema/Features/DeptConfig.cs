using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace App.Infrastructure.Persistence.Schema.Features
{
    public class DeptConfig : IEntityTypeConfiguration<Dept>
    {
        public void Configure(EntityTypeBuilder<Dept> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );
            builder.ToTable("Dept");
            builder.Property(e => e.Id).UseIdentityColumn();

            //builder.Property(e => e.DeptId).HasMaxLength(255);

            builder.Property(e => e.UpperDeptId).HasMaxLength(255);


            //builder.Property(e => e.PastoralId).HasMaxLength(30);
            builder.Property(e => e.Name).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Title).IsUnicode().HasMaxLength(50);
            

            builder.Property(e => e.StatusCd).HasDefaultValue("1");

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
