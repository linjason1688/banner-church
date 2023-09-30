using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class ShoppingOrderDetailConfig : IEntityTypeConfiguration<ShoppingOrderDetail>
    {
        public void Configure(EntityTypeBuilder<ShoppingOrderDetail> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("ShoppingOrderDetail");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.ShoppingOrderId).HasMaxLength(32);
            builder.Property(e => e.CourseId).HasMaxLength(32);
            builder.Property(e => e.Price).HasMaxLength(32);
            builder.Property(e => e.Count).HasMaxLength(32);
            builder.Property(e => e.Amount).HasMaxLength(32);
            builder.Property(e => e.OrderDetailStatus).HasMaxLength(32);


            builder.Property(e => e.IsViggieHelp).HasMaxLength(32);
            builder.Property(e => e.IsViggieHelp).HasDefaultValue("0");
            builder.Property(e => e.IsMoveHelp).HasMaxLength(32);
            builder.Property(e => e.IsMoveHelp).HasDefaultValue("0");
            builder.Property(e => e.IsPregnancyHelp).HasMaxLength(32);
            builder.Property(e => e.IsPregnancyHelp).HasDefaultValue("0");
            builder.Property(e => e.IsOthersHelp).HasMaxLength(32);
            builder.Property(e => e.IsOthersHelp).HasDefaultValue("0");
            builder.Property(e => e.IsOthersHelpInformations).HasMaxLength(200);
            builder.Property(e => e.IsCoupleSameClassHelp).HasMaxLength(32);
            builder.Property(e => e.IsCoupleSameClassHelp).HasDefaultValue("0");
            builder.Property(e => e.IsCoupleSameClassInformations).HasMaxLength(50);
           






            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.ShoppingOrderDetailNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.ShoppingOrderDetailStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.ShoppingOrderDetailNo);
            builder.Property(e => e.ShoppingOrderDetailStatus);
            */





        }
    }
}
