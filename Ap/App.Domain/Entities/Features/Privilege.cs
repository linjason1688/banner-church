#region

using System;
using System.ComponentModel;
using App.Domain.Constants;

#endregion

namespace App.Domain.Entities.Features
{
    /// <summary>
    /// 功能頁-> menu -> 可多層
    /// </summary>
    [Description("權限功能")]
    public class Privilege : EntityBase, ICommentable
    {
        [Description("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 6 碼 ABCD1234
        /// </summary>
        [Description("功能 ID")]
        public string FunctionId { get; set; }

        [Description("父層功能 Id")]
        public string ParentFunctionId { get; set; }

        [Description("功能名稱")]
        public string Name { get; set; }

        [Description("排序")]
        public int Sort { get; set; }

        [Description("功能類型")]
        public PrivilegeNodeType LinkType { get; set; }

        [Description("QueryParams")]
        public string QueryParams { get; set; }

        [Description("圖示")]
        public string Icon { get; set; }

        /// <inheritdoc />
        public string Comment { get; set; }
    }
}
