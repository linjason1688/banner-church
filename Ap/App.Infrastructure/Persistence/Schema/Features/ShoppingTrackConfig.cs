using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class ShoppingTrackConfig : IEntityTypeConfiguration<ShoppingTrack>
    {
        public void Configure(EntityTypeBuilder<ShoppingTrack> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("ShoppingTrack");

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.UserId).HasMaxLength(32);
            builder.Property(e => e.CourseId).HasMaxLength(32);




            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.ShoppingTrackNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.ShoppingTrackStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.ShoppingTrackNo);
            builder.Property(e => e.ShoppingTrackStatus);
            */





        }
    }
}
