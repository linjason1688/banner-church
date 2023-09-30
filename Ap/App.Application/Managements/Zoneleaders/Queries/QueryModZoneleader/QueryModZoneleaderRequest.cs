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
using App.Application.Managements.Zoneleaders.ModZoneleaders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Queries.QueryModZoneleader
{
    /// <summary>
    /// 分頁查詢 ModZoneleader
    /// </summary>

    public class QueryModZoneleaderRequest 
        : PageableQuery, IRequest<Page<ModZoneleaderView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 ModZoneleader
    /// </summary>
    public class QueryModZoneleaderRequestHandler 
        : IRequestHandler<QueryModZoneleaderRequest, Page<ModZoneleaderView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryModZoneleaderRequestHandler(
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
        public async Task<Page<ModZoneleaderView>> Handle(
            QueryModZoneleaderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModZoneleaders
               .ProjectTo<ModZoneleaderView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
