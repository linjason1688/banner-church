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
using App.Application.Managements.UserSocieties.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserSocieties.Queries.QueryUserSociety
{
    /// <summary>
    /// 分頁查詢 UserSociety
    /// </summary>

    public class QueryUserSocietyRequest 
        : PageableQuery, IRequest<Page<UserSocietyView>>
    {
        /// <summary>
        /// Key
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// User.Name
        /// </summary>
        public string Name { get; set; }

    }

    /// <summary>
    ///  分頁查詢 UserSociety
    /// </summary>
    public class QueryUserSocietyRequestHandler 
        : IRequestHandler<QueryUserSocietyRequest, Page<UserSocietyView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserSocietyRequestHandler(
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
        public async Task<Page<UserSocietyView>> Handle(
            QueryUserSocietyRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserSocieties
 
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id//
              .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//外部社團/工會描述

               .ProjectTo<UserSocietyView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
