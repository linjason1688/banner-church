#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserBankAccounts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.FetchAllUserBankAccount
{
    /// <summary>
    /// 查詢  UserBankAccount 所有資料
    /// </summary>

    public class FetchAllUserBankAccountRequest 
        : IRequest<List<UserBankAccountView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
        /// <summary>
        /// User.Id
        /// </summary>
        public long? UserId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserBankAccountHandler 
        : IRequestHandler<FetchAllUserBankAccountRequest, List<UserBankAccountView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllUserBankAccountHandler(
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
        public async Task<List<UserBankAccountView>> Handle(
            FetchAllUserBankAccountRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserBankAccounts
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id

               .ApplyLimitConstraint(request)
               .ProjectTo<UserBankAccountView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
