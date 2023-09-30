using System;
using System.Collections.Generic;
using System.ComponentModel;
using App.Application.Common.Dtos;
using App.Domain.Constants;

namespace App.Application.Authenticate.Dtos
{
    /// <summary>
    /// 權限 menu
    /// </summary>
    public class PrivilegeNode : ITreeNode<PrivilegeNode, string>
    {
        /// <summary>
        /// Function ID 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Parent Function Id
        /// </summary>
        public string ParentKey { get; set; }


        /// <summary>
        /// Function ID 
        /// </summary>
        public string FunctionId
        {
            get => this.Key;

            set => this.Key = value;
        }

        /// <summary>
        /// Parent Function Id
        /// </summary>
        public string ParentFunctionId
        {
            get => this.ParentKey;

            set => this.ParentKey = value;
        }

        /// <summary>
        /// 子節點
        /// </summary>
        public IList<PrivilegeNode> Nodes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 功能名稱
        /// </summary>
        [Description("功能名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 功能類型
        /// </summary>
        [Description("功能類型")]
        public PrivilegeNodeType LinkType { get; set; }

        /// <summary>
        /// QueryParams
        /// </summary>
        [Description("QueryParams")]
        public string QueryParams { get; set; }

        /// <summary>
        /// 圖示
        /// </summary>
        [Description("圖示")]
        public string Icon { get; set; }

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

        /// <summary>
        /// 備註
        /// </summary>
        [Description("備註")]
        public string Comment { get; set; }
    }
}
