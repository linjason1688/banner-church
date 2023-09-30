#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserBankAccounts.Commands.DeleteUserBankAccount
{
    /// <summary>
    /// 刪除  UserBankAccount
    /// </summary>

    public class DeleteUserBankAccountCommand : IRequest<Unit>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserBankAccountCommandHandler : IRequestHandler<DeleteUserBankAccountCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteUserBankAccountCommandHandler(
            IMapper mapper,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Unit> Handle(
            DeleteUserBankAccountCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.UserBankAccounts.RemoveAsync(
                new UserBankAccount()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
