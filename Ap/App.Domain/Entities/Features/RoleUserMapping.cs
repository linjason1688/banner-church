#region

using System;
using System.ComponentModel;

#endregion

namespace App.Domain.Entities.Features
{
    /// <summary>
    /// one Account can have multiple roles
    /// </summary>
    [Description("帳號-角色 對應")]
    public class RoleUserMapping : EntityBase
    {
        [Description("Id")]
        public Guid Id { get; set; }

        [Description("使用者 Id")]
        public long UserId { get; set; }

        [Description("角色 Id")]
        public Guid RoleId { get; set; }
    }
}
