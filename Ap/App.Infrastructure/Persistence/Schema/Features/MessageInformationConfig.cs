using System.Text.RegularExpressions;
using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    //#CreateAPI
    public class MessageInformationConfig : IEntityTypeConfiguration<MessageInformation>
    {
        public void Configure(EntityTypeBuilder<MessageInformation> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("MessageInformation");


            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.OrganizationId).HasMaxLength(20);
            builder.Property(e => e.MeetingPointId).HasMaxLength(20);
            builder.Property(e => e.PastoralId).HasMaxLength(20);
            builder.Property(e => e.MinistryRespId).HasMaxLength(20);
            builder.Property(e => e.MinistryId).HasMaxLength(20);
            builder.Property(e => e.CourseId).HasMaxLength(20);
            builder.Property(e => e.GenderType).HasMaxLength(30);
            builder.Property(e => e.BirthdayYearRange).HasMaxLength(20);
            builder.Property(e => e.ProfessionType).HasMaxLength(20);
            builder.Property(e => e.SendLineCounter).HasMaxLength(10);
            builder.Property(e => e.SendEmailCounter).HasMaxLength(10);
            builder.Property(e => e.SendSMSCounter).HasMaxLength(10);
            builder.Property(e => e.MessageSendType).HasMaxLength(10);


            builder.Property(e => e.Title).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Descriptions).IsUnicode().HasMaxLength(500);

            builder.Property(e => e.Remark).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.StatusCd).HasDefaultValue("1");
            //builder.Property(e => e.MessageInformationNo).HasMaxLength(20);
            //builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(e => e.MessageInformationStatus).HasMaxLength(20);


            /*builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name);
            builder.Property(e => e.MessageInformationNo);
            builder.Property(e => e.MessageInformationStatus);
            */

    }
    }
}
