using System.Collections.Generic;

namespace App.Application.Common.Dtos.Services
{
    /// <summary>
    /// </summary>
    public class DeptNode : ITreeNode<DeptNode, string>
    {
        public string DeptId
        {
            get => this.Key;
            set => this.Key = value;
        }

        public string DeptName { get; set; }

        /// <summary>
        /// 公司代號
        /// </summary>
        public string Company { get; set; }

        public string Key { get; set; }

        public string ParentKey { get; set; }

        public IList<DeptNode> Nodes { get; set; }

        public int Sort { get; set; }
    }
}
