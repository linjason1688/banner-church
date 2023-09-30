using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserBankAccounts.Dtos
{
    /// <summary>
    /// UserBankAccount 
    /// </summary>
    public class UserBankAccountView : UserBankAccountBase, IEntityBase
    {

      

     
        public string ModifiedUserId { get; set; }


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
