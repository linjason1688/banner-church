using System;

namespace App.Application.Managements.Users.Dtos
{
    /// <summary>
    /// User DTO base class 
    /// </summary>
    public class UserBase
    {
        /// <summary>
        /// 所屬牧區id =>對應牧區身分類別
        /// </summary>
        public long PastoralId { get; set; } //所屬牧區id =>對應牧區身分類別

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } //姓名

        /// <summary>
        /// 聚會點Id
        /// </summary>
        public long MeetingPointId { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string UserNo { get; set; } //帳號

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } //密碼

        /// <summary>
        /// 令牌
        /// </summary>
        public string PasswordSalt { get; set; } //令牌


        /// <summary>
        /// 手機類型 對應SystemConfig type=PhoneType 顯示 name value存此欄位 0：家長手機 1：小孩手機
        /// </summary>
        public string PhoneType { get; set; } //手機類型 對應SystemConfig type=PhoneType 顯示 name value存此欄位 0：家長手機 1：小孩手機

        /// <summary>
        /// 姓
        /// </summary>
        public string FirstName { get; set; } //姓

        /// <summary>
        /// 名
        /// </summary>
        public string LastName { get; set; } //名

        /// <summary>
        /// 性別 對應SystemConfig type=GenderType 顯示 name value存此欄位0：女姓 1：男性"
        /// </summary>
        /// <example>0</example>
        public string GenderType { get; set; } //性別 對應SystemConfig type=GenderType 顯示 name value存此欄位0：女姓 1：男性

        /// <summary>
        /// 居住國家
        /// </summary>
        public string LiveCountry { get; set; } //居住國家

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; } //生日

        /// <summary>
        /// 身分證字號
        /// </summary>
        public string IdNumber { get; set; } //身分證字號

        /// <summary>
        /// 手機國碼
        /// </summary>
        public string CellAreaCode { get; set; } //手機國碼

        /// <summary>
        /// 手機門號
        /// </summary>
        public string CellPhone { get; set; } //手機門號

        /// <summary>
        /// 城市
        /// </summary>
        public string LiveCity { get; set; } // 城市

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string LiveZipCode { get; set; } //郵遞區號

        /// <summary>
        /// 地區
        /// </summary>
        public string LiveZipArea { get; set; } //地區

        /// <summary>
        /// 詳細地址
        /// </summary>
        public string LiveAddress { get; set; } //詳細地址

        /// <summary>
        /// 地址2
        /// </summary>
        public string LiveAddress2 { get; set; } //地址2

        /// <summary>
        /// 受洗 對應SystemConfig type=BaptizedType顯示 namevalue存此欄位0：未受洗1：已受洗2：其它
        /// </summary>
        public string BaptizedType { get; set; }

        /// <summary>
        /// 受洗時間
        /// </summary>
        public string BaptizedTime { get; set; }

        /// <summary>
        /// 教會施洗者 (若為旌旗教會者)
        /// </summary>
        public string BaptizedPerson { get; set; }

        /// <summary>
        ///  教會類別 對應SystemConfigtype=ChurchType顯示 namevalue存此欄位0：其他1：旌旗教會
        /// </summary>
        public string ChurchType { get; set; }

        /// <summary> 
        /// 會友所屬堂點 DDL對應Organization.Name
        /// </summary>
        /// 
        public string ChurchName { get; set; }

        /// <summary>
        /// 過去在哪個教會名稱
        /// </summary>
        /// 
        public string AnotherChurchName { get; set; }

        /// <summary>
        /// 電話(市話)
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 手機國碼1
        /// </summary>
        public string CellAreaCode1 { get; set; } //手機國碼1

        /// <summary>
        /// 電話(手機)
        /// </summary>
        public string CellPhone1 { get; set; }

        /// <summary>
        /// 手機國碼2
        /// </summary>
        public string CellAreaCode2 { get; set; } //手機國碼2

        /// <summary>
        /// 電話(手機2)
        /// </summary>
        public string CellPhone2 { get; set; }

        /// <summary>
        /// Email(主要)
        /// </summary>
        public string Email1 { get; set; }

        /// <summary>
        /// Email(次要)
        /// </summary>
        public string Email2 { get; set; }

        /// <summary>
        /// InstagramId
        /// </summary>
        public string InstagramId { get; set; }

        /// <summary>
        /// LineId
        /// </summary>
        public string LineId { get; set; }

        /// <summary>
        /// WeChatId
        /// </summary>
        public string WeChatId { get; set; }

        /// <summary>
        /// 其他APPID
        /// </summary>
        public string OtherSocialId { get; set; }

        /// <summary>
        ///  是否在旌旗小組對應SystemConfigtype = isYN顯示 namevalue存此欄位0：N1：Y"
        /// </summary>
        public string IsChurchGroup { get; set; }

        /// <summary>
        ///  Id
        /// </summary>
        public string ChurchGroupNo { get; set; }

        /// <summary>
        ///  是否願意加入旌旗小組對應SystemConfigtype = isYN顯示 namevalue存此欄位0：N1：Y"
        /// </summary>
        public string IsJoinChurchGroup { get; set; }

        /// <summary>
        ///  志願序1 實體 星期對應SystemConfigtype = JoinSequenceType0顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate1 { get; set; }

        /// <summary>
        ///  志願序1 實體 時間type=JoinSequenceType1顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime1 { get; set; }

        /// <summary>
        ///  志願序1 實體 時間type=JoinSequenceType2顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation1 { get; set; }

        /// <summary>
        ///  志願序2 實體 星期對應SystemConfigtype = JoinSequenceType0顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate2 { get; set; }

        /// <summary>
        ///  志願序2 實體 時間type=JoinSequenceType1顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime2 { get; set; }

        /// <summary>
        ///  志願序2 實體 時間type=JoinSequenceType2顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation2 { get; set; } //志願序2 實體 時間

        /// <summary>
        ///  志願序3 實體 星期對應SystemConfigtype = JoinSequenceType0顯示 namevalue存此欄位1：星期一2：星期二3：星期三4：星期四5：星期五6：星期六7：星期日
        /// </summary>
        public string JoinInPersonDate3 { get; set; }

        /// <summary>
        ///  志願序3 實體 時間type=JoinSequenceType1顯示 namevalue存此欄位1：上午2：下午
        /// </summary>
        public string JoinInPersonTime3 { get; set; }

        /// <summary>
        ///  志願序3 實體 時間type=JoinSequenceType2顯示 namevalue存此欄位1：堂點
        /// </summary>
        public string JoinInPersonLocation3 { get; set; }


        /// <summary>
        ///  志願序1 線上 星期
        /// </summary>
        public string JoinOnlineDate1 { get; set; }

        /// <summary>
        ///  志願序1 線上 時間
        /// </summary>
        public string JoinOnlineTime1 { get; set; }

        /// <summary>
        ///  志願序2 線上 星期
        /// </summary>
        public string JoinOnlineDate2 { get; set; } //志願序2 線上 星期

        /// <summary>
        ///  志願序2 線上 時間
        /// </summary>
        public string JoinOnlineTime2 { get; set; } //志願序2 線上 時間

        /// <summary>
        ///  志願序3 線上 星期
        /// </summary>
        public string JoinOnlineDate3 { get; set; } //志願序3 線上 星期

        /// <summary>
        ///  志願序3 線上 時間
        /// </summary>
        public string JoinOnlineTime3 { get; set; } //志願序3 線上 時間

        /// <summary>
        ///  Id
        /// </summary>
        public string MemberType { get; set; } //會員類別

        /// <summary>
        ///  教育程度type=EduType顯示 namevalue存此欄位0：小學1：國中…
        /// </summary>
        public string EduType { get; set; }

        /// <summary>
        ///  職業type=EduType顯示 namevalue存此欄位0：老師1：家管…
        /// </summary>
        public string ProfessionType { get; set; }

        /// <summary>
        ///  是否結婚對應SystemConfigtype = IsMarried顯示 namevalue存此欄位0：未婚1：已婚
        /// </summary>
        public string IsMarried { get; set; }

        /// <summary>
        /// 國碼
        /// </summary>
        public string CountryCode { get; set; } //國碼

        /// <summary>
        ///  是否舊會員 Y是N否
        /// </summary>
        public string IsOldMember { get; set; }

        /// <summary>
        /// 勾選合約
        /// </summary>
        public string IsTerm { get; set; }

        /// <summary>
        /// 是否受洗
        /// </summary>
        public string IsBaptize { get; set; }

        /// <summary>
        /// 受洗類別 0:未知 1: 本教會受洗 2: 其他教會受洗 3: 未受洗
        /// </summary>
        public string BaptizeTypeId { get; set; }

        /// <summary>
        /// 受洗日期
        /// </summary>
        public string Baptizeday { get; set; }

        /// <summary>
        /// 受洗教會
        /// </summary>
        public string BaptizeOrgName { get; set; }

        /// <summary>
        /// 受洗教會
        /// </summary>
        public string BaptizeGroup { get; set; }

        /// <summary>
        /// 施洗人
        /// </summary>
        public string Baptizer { get; set; }

        /// <summary>
        /// 使用者家長Id
        /// 
        /// </summary>
        public long ParentUserId { get; set; }



        /// <summary>
        /// 是否會員
        /// </summary>
        public string IsMember { get; set; }


        /// <summary>
        /// 同工角色類別 對應SystemConfig type=GroupMemberType 顯示 name value存此欄位 0：無 1：核心同工 2：儲備同工
        /// </summary>
        public string GroupMemberType { get; set; } /// 同工角色類別 對應SystemConfig type=GroupMemberType 顯示 name value存此欄位 0：無 1：核心同工 2：儲備同工




        /// <summary>
        ///中低收入戶 IsYN 0:否 1:是
        /// </summary>
        public string LowIncome { get; set; }

        /// <summary>
        ///備註欄位
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }
}
