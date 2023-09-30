


using System;

namespace App.Application.Managements.Roles.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 角色說明
        /// </summary>  
        public string? RoleDescriptions { get; set; }


        /// <summary>
        /// 角色資料階層
        /// </summary>
        public int? DataLevel { get; set; }

        /// <summary>
        /// HandledId
        /// </summary>
        public Guid? HandledId { get; set; }

    }
}

