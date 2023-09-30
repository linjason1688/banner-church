using System;
using System.Collections.Generic;
using App.Application.Common.Dtos;
using App.Domain.Entities;

namespace App.Application.Managements.Privileges.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivilegeNodeView : PrivilegeBase, ITreeNode<PrivilegeNodeView, string>, IEntityBase
    {
        /// <inheritdoc />
        public string Key { get; set; }

        /// <inheritdoc />

        public string ParentKey { get; set; }

        /// <summary> 
        /// Id 
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int Level { get; set; }

        /// <summary> 
        /// Authorized 
        /// </summary>
        public bool Authorized { get; set; }

        /// <inheritdoc />
        public IList<PrivilegeNodeView> Nodes { get; set; }

        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }
    }
}
