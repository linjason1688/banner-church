using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class QrCode : EntityBase
    {
        ///  <summary>
        ///QrCodeId
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///  報到類別對應 systemconfig.Type=RefferenceType 0:兒童個人報到專用 1:小組報到 2:主日報到 3:領袖之夜報到 4:課程報到 5:事工團報到 6:問卷填寫
        /// </summary>
        public int ReferenceType { get; set; }
        ///  <summary>
        ///對應報到類別主擋Id  
        /// </summary>
        public long ReferenceId { get; set; }
        ///  <summary>
        ///報到使用者Id
        /// </summary>
        public long UserId { get; set; }
        ///  <summary>
        ///Id+RefferenceType+UserId 產生唯一值
        /// </summary>
        public String GenerateCode { get; set; }
        ///  <summary>
        ///付款方式 對應SystemConfig內Type=RegisterStatus 0:尚未報到 1:已報到
        /// </summary>
        public int RegisterStatus { get; set; }
        ///  <summary>
        ///報到時間
        /// </summary>
        public DateTime? RegisterTime { get; set; }



        public string StatusCd { get; set; }

    }
}
