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
using App.Application.Managements.AspnetUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetUsers.Queries.FindAspnetUser
{
    /// <summary>
    /// 取得  AspnetUser 單筆明細
    /// </summary>

    public class FindAspnetUserRequest 
        : IRequest<AspnetUserView>
    {

        /// <summary>
        /// aspnet_Users里面并没有 long类型  Id，暂时不管这个栏位
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 增加栏位条件
        /// </summary>
        public string UserName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetUserRequestHandler 
        : IRequestHandler<FindAspnetUserRequest, AspnetUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindAspnetUserRequestHandler(
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
        public async Task<AspnetUserView> Handle(
            FindAspnetUserRequest request,
            CancellationToken cancellationToken
        )
        {
            //調整查詢邏輯
            //當參數【UserName】不空，會加入此條件
            return await this.appDbContext
               .AspnetUsers
               .WhereWhen(!string.IsNullOrEmpty(request.UserName),  e => e.UserName == request.UserName)
               .ProjectTo<AspnetUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
