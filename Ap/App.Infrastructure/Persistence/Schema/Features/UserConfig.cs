using App.Domain.Entities.Features;
using App.Infrastructure.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Schema.Features
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(
                e => new
                {
                    e.Id
                }
            );

            builder.ToTable("User");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.UserId).HasMaxLength(36);
            builder.Property(e => e.PastoralId);
            builder.Property(e => e.MeetingPointId);
            builder.Property(e => e.Password).HasMaxLength(128);
            builder.Property(e => e.PasswordSalt).HasMaxLength(128);
            builder.Property(e => e.PhoneType).HasMaxLength(30);
            builder.Property(e => e.FirstName).IsUnicode().HasMaxLength(20);
            builder.Property(e => e.LastName).IsUnicode().HasMaxLength(20);
            builder.Property(e => e.GenderType).HasMaxLength(30);
            builder.Property(e => e.LiveCountry).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Birthday);
            builder.Property(e => e.IdNumber).HasMaxLength(25);
            builder.Property(e => e.CellPhone).HasMaxLength(50);
            builder.Property(e => e.LiveCity).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.LiveZipCode).HasMaxLength(50);
            builder.Property(e => e.LiveZipArea).HasMaxLength(50);
            builder.Property(e => e.LiveAddress).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.LiveAddress2).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.ChurchType).HasMaxLength(20);
            builder.Property(e => e.ChurchName).HasMaxLength(20);
            builder.Property(e => e.AnotherChurchName).IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Phone).HasMaxLength(25);
            builder.Property(e => e.CellPhone1).HasMaxLength(25);
            builder.Property(e => e.CellPhone2).HasMaxLength(25);
            builder.Property(e => e.Email1).HasMaxLength(50);
            builder.Property(e => e.Email2).HasMaxLength(50);
            builder.Property(e => e.InstagramId).HasMaxLength(25);
            builder.Property(e => e.LineId).HasMaxLength(25);
            builder.Property(e => e.WeChatId).HasMaxLength(25);
            builder.Property(e => e.OtherSocialId).HasMaxLength(25);
            builder.Property(e => e.IsChurchGroup).HasMaxLength(20);
            builder.Property(e => e.ChurchGroupNo).HasMaxLength(25);
            builder.Property(e => e.IsJoinChurchGroup).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonDate1).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonTime1).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonLocation1).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonDate2).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonTime2).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonLocation2).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonDate3).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonTime3).HasMaxLength(20);
            builder.Property(e => e.JoinInPersonLocation3).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineDate1).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineTime1).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineDate2).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineTime2).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineDate3).HasMaxLength(20);
            builder.Property(e => e.JoinOnlineTime3).HasMaxLength(20);
            builder.Property(e => e.MemberType).HasMaxLength(20);
            builder.Property(e => e.MemberType).HasDefaultValue("0").IsRequired();
            builder.Property(e => e.EduType).HasMaxLength(20);
            builder.Property(e => e.ProfessionType).HasMaxLength(20);
            builder.Property(e => e.IsMarried).HasMaxLength(20);
            builder.Property(e => e.CountryCode).HasMaxLength(20);

            builder.Property(e => e.CellAreaCode1).HasMaxLength(20);
            builder.Property(e => e.CellAreaCode1).HasMaxLength(20);
            builder.Property(e => e.LowIncome).HasDefaultValue("0").IsRequired();


            builder.Property(e => e.IsMember).HasMaxLength(20); //是否會員 擁有會員卡
            
            builder.Property(e => e.GroupMemberType).HasMaxLength(20);  // 同工角色類別 對應SystemConfig type=GroupMemberType 顯示 name value存此欄位 0：無 1：核心同工 2：儲備同工
            builder.Property(e => e.GroupMemberType).HasDefaultValue("0");
            //// TODO: 補上 account,roles,isAdmin等相關眝位
            //builder.Property(e => e.Account).HasMaxLength(20);
            //builder.Property(e => e.Roles).HasMaxLength(20);
            //builder.Property(e => e.IsAdmin).HasMaxLength(20);

            builder.Property(e => e.StatusCd).HasDefaultValue("1");


         

            #region fks

            builder.HasMany(e => e.UserBankAccounts)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserContacts)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserCourses)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserExpertises)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserFamilies)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserPastoralCares)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserQuestionnaires)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.UserSocieties)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId)
               .HasPrincipalKey(e => e.Id);

            #endregion
        }
    }
}
