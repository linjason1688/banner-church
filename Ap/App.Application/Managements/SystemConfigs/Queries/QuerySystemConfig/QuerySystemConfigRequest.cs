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
using App.Application.Managements.SystemConfigs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.QuerySystemConfig
{
    /// <summary>
    /// 分頁查詢 SystemConfig
    /// </summary>

    public class QuerySystemConfigRequest
        : PageableQuery, IRequest<Page<SystemConfigView>>
    {

        public string Name { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    ///  分頁查詢 SystemConfig
    /// </summary>
    public class QuerySystemConfigRequestHandler
        : IRequestHandler<QuerySystemConfigRequest, Page<SystemConfigView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QuerySystemConfigRequestHandler(
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
        public async Task<Page<SystemConfigView>> Handle(
            QuerySystemConfigRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SystemConfigs
               .WhereWhenNotEmpty(request.Type, c => c.Type == request.Type)
               .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)
               .ProjectTo<SystemConfigView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
