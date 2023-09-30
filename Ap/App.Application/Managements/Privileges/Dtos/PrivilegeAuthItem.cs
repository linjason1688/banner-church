using System;

namespace App.Application.Managements.Privileges.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivilegeAuthItem
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid PrivilegeId { get; set; }

        /// <summary>
        /// 功能 id
        /// </summary>
        public string FunctionId { get; set; }


        /// <summary>
        /// 授權狀態
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 檢視
        /// </summary>
        public bool ViewGranted { get; set; }

        /// <summary>
        /// 新增/編輯
        /// </summary>
        public bool ModifyGranted { get; set; }

        /// <summary>
        /// 刪除
        /// </summary>
        public bool DeleteGranted { get; set; }

        /// <summary>
        /// 上傳
        /// </summary>
        public bool UploadGranted { get; set; }

        /// <summary>
        /// 下載
        /// </summary>
        public bool DownloadGranted { get; set; }
    }
}
