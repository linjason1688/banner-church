#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using App.Domain.Entities.Features;

#endregion

namespace App.Domain.Entities.Features
{
    [Description("角色")]
    public class Role : EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [Description("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        public string Name { get; set; }
        
    }
}
