#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserBankAccounts.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserBankAccounts.Commands.CreateUserBankAccount
{
    /// <summary>
    /// 建立 UserBankAccount
    /// </summary>

    public class CreateUserBankAccountCommand :  UserBankAccountBase, IRequest<UserBankAccountView>
    {
        //public long Id { get; set; }
        //public long UserId { get; set; }
        //public string BankName { get; set; }
        //public string BankCode { get; set; }
        //public string BranchCode { get; set; }
        //public string Account { get; set; }
        public string Memo { get; set; }


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc />
        public string Creator { get; set; }

        /// <inheritdoc />
        public DateTime? ModifiedAt { get; set; }

        /// <inheritdoc />
        public string Modifier { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserBankAccountCommandHandler : IRequestHandler<CreateUserBankAccountCommand, UserBankAccountView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserBankAccountCommandHandler(
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
        public async Task<UserBankAccountView> Handle(
            CreateUserBankAccountCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserBankAccount>(command);

            await this.appDbContext.UserBankAccounts.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserBankAccountView>(entity);
        }
    }
}
