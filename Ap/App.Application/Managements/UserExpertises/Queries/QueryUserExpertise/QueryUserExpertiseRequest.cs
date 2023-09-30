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
using App.Application.Managements.UserExpertises.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.QueryUserExpertise
{
    /// <summary>
    /// 分頁查詢 UserExpertise
    /// </summary>

    public class QueryUserExpertiseRequest 
        : PageableQuery, IRequest<Page<UserExpertiseView>>
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
        ///  專長描述
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 UserExpertise
    /// </summary>
    public class QueryUserExpertiseRequestHandler 
        : IRequestHandler<QueryUserExpertiseRequest, Page<UserExpertiseView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserExpertiseRequestHandler(
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
        public async Task<Page<UserExpertiseView>> Handle(
            QueryUserExpertiseRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserExpertises
 
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id//
              .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//專長描述

               .ProjectTo<UserExpertiseView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
