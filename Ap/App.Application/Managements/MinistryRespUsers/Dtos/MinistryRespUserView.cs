using System;
using App.Application.Managements.Users.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryRespUsers.Dtos
{
    /// <summary>
    /// MinistryRespUser 
    /// </summary>
    public class MinistryRespUserView : MinistryRespUserBase, IEntityBase
    {

        public UserView userView { get; set; }


        /// <summary>
        /// 事工團分類
        /// </summary>
        public string MinistryDefName { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string MinistryName { get; set; }

        /// <summary>
        /// 事工團職分名稱
        /// </summary>
        public string MinistryRespName { get; set; }



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
