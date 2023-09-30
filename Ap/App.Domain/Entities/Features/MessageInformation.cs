using System;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class MessageInformation: EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///Organization.Id 旌旗id
        /// </summary>
        public long OrganizationId { get; set; }

        ///  <summary>
        ///MeetingPoint.Id 聚會點id
        /// </summary>
        public long MeetingPointId { get; set; }

        ///  <summary>
        ///Pastoral.Id 牧養組織id
        /// </summary>
        public long PastoralId { get; set; }

        ///  <summary>
        ///MinistryResp.Id 牧養身分
        /// </summary>
        public long MinistryRespId { get; set; }


        ///  <summary>
        ///Ministry.Id 事工團
        /// </summary>
        public long MinistryId { get; set; }

        ///  <summary>
        ///CourseId 課程名稱 課程代碼
        /// </summary>
        public long CourseId { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=GenderType顯示 namevalue存此欄位0：女姓1：男性
        /// </summary>
        public string GenderType { get; set; }

        ///  <summary>
        ///性別 對應SystemConfigtype=BirthdayYearRange顯示 namevalue存此欄位0：1920   1：1930  2:1940  3:1950  4:1960  5:1970   6:1980  7:1990  8:2000   9:2010   10:2020
        /// </summary>
        public string BirthdayYearRange { get; set; }

        /// <summary>
        ///  職業type=EduType顯示 namevalue存此欄位0：老師1：家管…
        /// </summary>
        public string ProfessionType { get; set; }

        /// <summary>
        /// 推播訊息描述
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 推播訊息內容
        /// </summary>
        public string Descriptions { get; set; }


        /// <summary>
        ///  職業type=MessageSendType namevalue存此欄位0：尚未推播    1：已推播
        /// </summary>
        public string MessageSendType { get; set; }

        /// <summary>
        ///  發送數量Line
        /// </summary>
        public int SendLineCounter { get; set; }


        /// <summary>
        ///  發送數量Email
        /// </summary>
        public int SendEmailCounter { get; set; }

        /// <summary>
        ///  發送數量SMS
        /// </summary>
        public int SendSMSCounter { get; set; }


        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }

    }

}
