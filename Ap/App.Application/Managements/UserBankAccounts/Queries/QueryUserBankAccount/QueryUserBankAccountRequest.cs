#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.QueryUserBankAccount
{
    /// <summary>
    /// 分頁查詢 UserBankAccount
    /// </summary>

    public class QueryUserBankAccountRequest 
        : PageableQuery, IRequest<Page<UserBankAccountView>>
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  建立 User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  戶名
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        ///  銀行代號
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        ///  分行代號
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        ///  銀行帳戶
        /// </summary>
        public string Account { get; set; }
    }

    /// <summary>
    ///  分頁查詢 UserBankAccount
    /// </summary>
    public class QueryUserBankAccountRequestHandler 
        : IRequestHandler<QueryUserBankAccountRequest, Page<UserBankAccountView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserBankAccountRequestHandler(
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
        public async Task<Page<UserBankAccountView>> Handle(
            QueryUserBankAccountRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserBankAccounts
             .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id
             .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId) //User.Id
                .WhereWhenNotEmpty(request.BankName?.ToString(), c => c.BankName == request.BankName)//戶名
                .WhereWhenNotEmpty(request.BankCode?.ToString(), c => c.BankCode == request.BankCode)//銀行代號
                .WhereWhenNotEmpty(request.BranchCode?.ToString(), c => c.BranchCode == request.BranchCode)//分行代號
                .WhereWhenNotEmpty(request.Account?.ToString(), c => c.Account == request.Account)//銀行帳戶

               .ProjectTo<UserBankAccountView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
