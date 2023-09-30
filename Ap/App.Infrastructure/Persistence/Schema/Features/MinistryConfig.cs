using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MinistryConfig : IEntityTypeConfiguration<Ministry>
    {
        public void Configure(EntityTypeBuilder<Ministry> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("Ministry");


            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.MinistryDefId).HasMaxLength(20);
            builder.Property(e => e.MinistryNo).HasMaxLength(20);
            builder.Property(e => e.Name).HasMaxLength(50);


            builder.Property(e => e.ChildMinistry).HasMaxLength(20);
            builder.Property(e => e.MinistryStatus).HasMaxLength(20);

            builder.Property(e => e.Nature).HasMaxLength(20);


            builder.Property(e => e.StatusCd).HasDefaultValue("1");

            //builder.Property(e => e.IsActivated).HasMaxLength(20);





            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MinistryNo);
            builder.Property(e => e.MinistryStatus);
            */





        }
    }
}
