using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public class User : EntityBase, ILogEntity
    {
        public long Id { get; set; }

        public string UserId { get; set; }

        public long PastoralId { get; set; }

        public long MeetingPointId { get; set; }

        public string Name { get; set; }

        public string UserNo { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string PhoneType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GenderType { get; set; }

        public string LiveCountry { get; set; }

        public DateTime Birthday { get; set; }

        public string IdNumber { get; set; }

        public string CellPhone { get; set; }

        public string LiveCity { get; set; }

        public string LiveZipCode { get; set; }

        public string LiveZipArea { get; set; }

        public string LiveAddress { get; set; }
        public string LiveAddress2 { get; set; }

        public string BaptizedType { get; set; }

        public string BaptizedTime { get; set; }

        public string BaptizedPerson { get; set; }

        public string ChurchType { get; set; }

        public string ChurchName { get; set; }

        public string AnotherChurchName { get; set; }

        public string Phone { get; set; }

        public string CellPhone1 { get; set; }

        public string CellPhone2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string InstagramId { get; set; }

        public string LineId { get; set; }

        public string WeChatId { get; set; }

        public string OtherSocialId { get; set; }

        public string IsChurchGroup { get; set; }

        public string ChurchGroupNo { get; set; }

        public string IsJoinChurchGroup { get; set; }

        public string JoinInPersonDate1 { get; set; }

        public string JoinInPersonTime1 { get; set; }

        public string JoinInPersonLocation1 { get; set; }

        public string JoinInPersonDate2 { get; set; }

        public string JoinInPersonTime2 { get; set; }

        public string JoinInPersonLocation2 { get; set; }

        public string JoinInPersonDate3 { get; set; }

        public string JoinInPersonTime3 { get; set; }

        public string JoinInPersonLocation3 { get; set; }

        public string JoinOnlineDate1 { get; set; }

        public string JoinOnlineTime1 { get; set; }

        public string JoinOnlineDate2 { get; set; }

        public string JoinOnlineTime2 { get; set; }

        public string JoinOnlineDate3 { get; set; }

        public string JoinOnlineTime3 { get; set; }

        public string MemberType { get; set; }

        public string EduType { get; set; }

        public string ProfessionType { get; set; }

        public string IsMarried { get; set; }

        public string LastLogin { get; set; }

        public long? ParentUserId { get; set; }

        public string IsOldMember { get; set; }

        public string CountryCode { get; set; }

        public string CellAreaCode1 { get; set; }

        public string CellAreaCode2 { get; set; }


        /// <summary>
        ///中低收入戶 IsYN 0:否 1:是
        /// </summary>
        public string LowIncome { get; set; }

        /// <summary>
        ///備註欄位
        /// </summary>
        public string Remark { get; set; }


        public string StatusCd { get; set; }

        /// <summary>
        /// 是否會員
        /// </summary>
        public string IsMember { get; set; }


        /// <summary>
        /// 同工角色類別 對應SystemConfig type=GroupMemberType 顯示 name value存此欄位 0：無 1：核心同工 2：儲備同工
        /// </summary>
        public string GroupMemberType { get; set; } /// 同工角色類別 對應SystemConfig type=GroupMemberType 顯示 name value存此欄位 0：無 1：核心同工 2：儲備同工




        #region FKS

        public virtual List<UserBankAccount> UserBankAccounts { get; set; } = new();

        public virtual List<UserContact> UserContacts { get; set; } = new();

        public virtual List<UserCourse> UserCourses { get; set; } = new();

        public virtual List<UserExpertise> UserExpertises { get; set; } = new();

        public virtual List<UserFamily> UserFamilies { get; set; } = new();

        public virtual List<UserPastoralCare> UserPastoralCares { get; set; } = new();

        public virtual List<UserQuestionnaire> UserQuestionnaires { get; set; } = new();

        public virtual List<UserSociety> UserSocieties { get; set; } = new();

        #endregion
    }
}
