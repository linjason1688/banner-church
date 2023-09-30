using System;

namespace App.Application.Managements.Users.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleAuthItem
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }


        /// <summary>
        /// 是否已建立角色關係
        /// </summary>
        public bool Authorized { get; set; }
    }
}
