


using System;
using System.ComponentModel;

namespace App.Application.Managements.RoleUserMappings.Dtos
{
    /// <summary>
    /// one Account can have multiple roles
    /// </summary>
    [Description("帳號-角色 對應")]
    public class RoleUserMappingBase
    {

        [Description("Id")]
        public Guid Id { get; set; }

        [Description("使用者 Id")]
        public long UserId { get; set; }

        [Description("角色 Id")]
        public Guid RoleId { get; set; }

    }
}

