using System;
using System.ComponentModel;

namespace App.Domain.Entities.Features
{
    /// <summary>
    /// 檔案上傳
    /// </summary>
    [Description("檔案上傳")]
    public class UploadFile : EntityBase
    {
        [Description("")]
        public long Id { get; set; }

        /// <summary>
        /// 供 Owner 綁定 key
        /// </summary>
        [Description("供 Owner 綁定 key")]
        public Guid FileKey { get; set; }

        /// <summary>
        /// 擁有者關聯 table
        /// </summary>
        [Description("擁有者關聯 table")]
        public string OwnerEntity { get; set; }

        /// <summary>
        /// 檔名
        /// </summary>
        [Description("檔名")]
        public string Filename { get; set; }

        /// <summary>
        /// 副檔名
        /// </summary>
        [Description("副檔名")]
        public string FileExtension { get; set; }

        /// <summary>
        /// 檔案存放相對路徑
        /// </summary>
        [Description("檔案存放相對路徑")]
        public string RelativeFilepath { get; set; }

        /// <summary>
        /// 檔案大小 (bit)
        /// </summary>
        [Description("檔案大小 (bit)")]
        public long FileSize { get; set; }

        /// <summary>
        /// 是否已綁定
        /// </summary>
        [Description("是否已綁定")]
        public bool Bound { get; set; }
    }
}
