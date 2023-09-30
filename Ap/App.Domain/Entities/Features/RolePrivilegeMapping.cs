#region

using System;
using System.ComponentModel;

#endregion

namespace App.Domain.Entities.Features
{
    [Description("角色-功能權限對應")]
    public class RolePrivilegeMapping : EntityBase
    {
        [Description("Id")]
        public Guid Id { get; set; }

        [Description("角色 Id")]
        public Guid RoleId { get; set; }

        [Description("功能 Id")]
        public Guid PrivilegeId { get; set; }

        [Description("啟用")]
        public bool Enable { get; set; }
        
        [Description("檢視")]
        public bool ViewGranted { get; set; }

        [Description("新增/編輯")]
        public bool ModifyGranted { get; set; }

        [Description("刪除")]
        public bool DeleteGranted { get; set; }

        [Description("上傳")]
        public bool UploadGranted { get; set; }

        [Description("下載")]
        public bool DownloadGranted { get; set; }
    }
}
