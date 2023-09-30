#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserBankAccounts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.FindUserBankAccount
{
    /// <summary>
    /// 取得  UserBankAccount 單筆明細
    /// </summary>

    public class FindUserBankAccountRequest 
        : IRequest<UserBankAccountView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserBankAccountRequestHandler 
        : IRequestHandler<FindUserBankAccountRequest, UserBankAccountView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserBankAccountRequestHandler(
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
            FindUserBankAccountRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserBankAccounts
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserBankAccountView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
