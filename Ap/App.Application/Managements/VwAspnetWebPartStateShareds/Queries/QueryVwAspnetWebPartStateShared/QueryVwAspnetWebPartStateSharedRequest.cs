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
using App.Application.Managements.VwAspnetWebPartStateShareds.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Queries.QueryVwAspnetWebPartStateShared
{
    /// <summary>
    /// 分頁查詢 VwAspnetWebPartStateShared
    /// </summary>

    public class QueryVwAspnetWebPartStateSharedRequest 
        : PageableQuery, IRequest<Page<VwAspnetWebPartStateSharedView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 VwAspnetWebPartStateShared
    /// </summary>
    public class QueryVwAspnetWebPartStateSharedRequestHandler 
        : IRequestHandler<QueryVwAspnetWebPartStateSharedRequest, Page<VwAspnetWebPartStateSharedView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryVwAspnetWebPartStateSharedRequestHandler(
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
        public async Task<Page<VwAspnetWebPartStateSharedView>> Handle(
            QueryVwAspnetWebPartStateSharedRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetWebPartStateShareds
               .ProjectTo<VwAspnetWebPartStateSharedView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
