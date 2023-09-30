using System;

namespace App.Application.Common.Dtos.Services
{
    /// <summary>
    /// </summary>
    public class FileStoreInfo
    {
        public Guid FileKey { get; set; }

        /// <summary>
        /// 僅回傳相對 app config 後之相對路徑
        /// </summary>
        public string RelativeFilepath { get; set; }

        public string OriginalFilename { get; set; }

        /// <summary>
        /// excluding dot, ex: "zip", "exe"
        /// </summary>
        public string FileExtension { get; set; }


        public long FileSize { get; set; }
    }
}
