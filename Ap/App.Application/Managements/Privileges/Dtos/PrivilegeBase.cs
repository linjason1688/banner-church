using System;
using App.Domain.Constants;

namespace App.Application.Managements.Privileges.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivilegeBase
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 6 碼 ABCD1234
        /// </summary>
        /// <summary>
        /// 功能 ID
        /// </summary>
        public string FunctionId { get; set; }

        /// <summary>
        /// 父層功能 Id
        /// </summary>
        public string ParentFunctionId { get; set; }

        /// <summary>
        /// 功能名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 功能類型
        /// </summary>
        public PrivilegeNodeType LinkType { get; set; }

        /// <summary>
        /// QueryParams
        /// </summary>
        public string QueryParams { get; set; }

        /// <summary>
        /// 圖示
        /// </summary>
        public string Icon { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
    }
}
