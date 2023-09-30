using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MessageInformationUserConfig : IEntityTypeConfiguration<MessageInformationUser>
    {
        public void Configure(EntityTypeBuilder<MessageInformationUser> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MessageInformationUser");


            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.MessageInformationId).HasMaxLength(20);
            builder.Property(e => e.UserId).HasMaxLength(20);
            builder.Property(e => e.LineId).HasMaxLength(200);
            builder.Property(e => e.Email).HasMaxLength(200);
            builder.Property(e => e.SMS).HasMaxLength(30);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.MessageInformationUserNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.MessageInformationUserStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MessageInformationUserNo);
            builder.Property(e => e.MessageInformationUserStatus);
            */

    }
    }
}
