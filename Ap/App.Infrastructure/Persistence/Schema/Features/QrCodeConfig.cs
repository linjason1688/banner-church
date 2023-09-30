using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class QrCodeConfig : IEntityTypeConfiguration<QrCode>
    {
        public void Configure(EntityTypeBuilder<QrCode> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("QrCode");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.UserId).HasMaxLength(32);

            builder.Property(e => e.ReferenceType).HasMaxLength(20);
            builder.Property(e => e.ReferenceId).HasMaxLength(30);
            builder.Property(e => e.UserId).HasMaxLength(30);
            builder.Property(e => e.GenerateCode).IsUnicode().HasMaxLength(500);
            builder.Property(e => e.RegisterStatus).HasMaxLength(30);
            builder.Property(e => e.RegisterTime).HasMaxLength(20);




            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.QrCodeNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.QrCodeStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.QrCodeNo);
            builder.Property(e => e.QrCodeStatus);
            */





        }
    }
}
