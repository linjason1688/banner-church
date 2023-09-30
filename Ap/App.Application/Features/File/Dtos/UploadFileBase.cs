using System;

namespace App.Application.Features.File.Dtos
{
    /// <summary>
    /// </summary>
    public class UploadFileBase
    {
        /// <summary>
        /// 供 Owner 綁定 key
        /// </summary>
        public Guid FileKey { get; set; }

        /// <summary>
        /// 擁有者關聯 table
        /// </summary>
        public string OwnerEntity { get; set; }

        /// <summary>
        /// 檔名
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 副檔名
        /// </summary>
        public string FileExtension { get; set; }


        /// <summary>
        /// 檔案大小 (bit)
        /// </summary>
        public long Filesize { get; set; }

        /// <summary>
        /// 是否已綁定
        /// </summary>
        public bool Bound { get; set; }
    }
}
