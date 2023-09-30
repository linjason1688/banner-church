


using System;
using System.ComponentModel;

namespace App.Application.Managements.RolePrivilegeMappings.Dtos
{
    /// <summary>
    /// 角色功能對應資訊
    /// </summary>
    public class RolePrivilegeMappingBase
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// PrivilegeId
        /// </summary>
        public Guid PrivilegeId { get; set; }

        /// <summary>
        /// PrivilegeId
        /// </summary>
        [Description("啟用")]
        public bool Enable { get; set; }

        /// <summary>
        /// 檢視
        /// </summary>
        [Description("檢視")]
        public bool ViewGranted { get; set; }


        /// <summary>
        /// 新增/編輯
        /// </summary>
        [Description("新增/編輯")]
        public bool ModifyGranted { get; set; }


        /// <summary>
        /// 刪除
        /// </summary>
        [Description("刪除")]
        public bool DeleteGranted { get; set; }


        /// <summary>
        /// 上傳
        /// </summary>
        [Description("上傳")]
        public bool UploadGranted { get; set; }


        /// <summary>
        /// 下載
        /// </summary>
        [Description("下載")]
        public bool DownloadGranted { get; set; }

        /*
         *       ,[Enable]
      ,[ViewGranted]
      ,[ModifyGranted]
      ,[DeleteGranted]
      ,[UploadGranted]
      ,[DownloadGranted]
         */



    }
}

