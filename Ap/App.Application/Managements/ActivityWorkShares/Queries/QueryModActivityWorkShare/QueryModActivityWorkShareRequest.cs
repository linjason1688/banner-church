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
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Queries.QueryModActivityWorkShare
{
    /// <summary>
    /// 分頁查詢 ModActivityWorkShare
    /// </summary>

    public class QueryModActivityWorkShareRequest 
        : PageableQuery, IRequest<Page<ModActivityWorkShareView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 ModActivityWorkShare
    /// </summary>
    public class QueryModActivityWorkShareRequestHandler 
        : IRequestHandler<QueryModActivityWorkShareRequest, Page<ModActivityWorkShareView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryModActivityWorkShareRequestHandler(
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
        public async Task<Page<ModActivityWorkShareView>> Handle(
            QueryModActivityWorkShareRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModActivityWorkShares
               .ProjectTo<ModActivityWorkShareView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
