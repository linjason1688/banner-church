using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class ShoppingOrderConfig : IEntityTypeConfiguration<ShoppingOrder>
    {
        public void Configure(EntityTypeBuilder<ShoppingOrder> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("ShoppingOrder");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.UserId).HasMaxLength(32);
            builder.Property(e => e.TotalAmount).HasMaxLength(32);
            builder.Property(e => e.PaymentAmount).HasMaxLength(32);
            builder.Property(e => e.RefundAmount).HasMaxLength(32);
            builder.Property(e => e.OrderPayStatus).HasMaxLength(32);
            builder.Property(e => e.PaymentTransactionNo).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.PaymentTransactionDate).HasMaxLength(32);
            builder.Property(e => e.PaymentTransactionDescription).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.PaymentType).HasMaxLength(32);
            builder.Property(e => e.RefundTransactionNo).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.RefundTransactionDate).HasMaxLength(32);
            builder.Property(e => e.RefundType).HasMaxLength(32);
            builder.Property(e => e.RefundDescription).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.OrderStatus).HasMaxLength(32);


            builder.Property(e => e.Receipt).HasMaxLength(200);
            builder.Property(e => e.ActuallyAmount).HasMaxLength(20);
            builder.Property(e => e.ReceiveUserId).HasMaxLength(20);





            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.ShoppingOrderNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.ShoppingOrderStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.ShoppingOrderNo);
            builder.Property(e => e.ShoppingOrderStatus);
            */

         

        
            builder.Property(e => e.UserName).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.UserAddress).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.UserCellPhone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.UserPhone).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.UserEmail).IsUnicode().HasMaxLength(200);




        }
    }
}
