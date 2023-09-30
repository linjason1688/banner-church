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
using App.Application.Managements.SystemConfigs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.FetchAllSystemConfig
{
    /// <summary>
    /// 查詢  SystemConfig 所有資料
    /// </summary>

    public class FetchAllSystemConfigRequest 
        : IRequest<List<SystemConfigView>>, ILimitedFetch
    {
        /// <inheritdoc />

        public string? Type { get; set; }
        public string? Name { get; set; }
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSystemConfigHandler 
        : IRequestHandler<FetchAllSystemConfigRequest, List<SystemConfigView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllSystemConfigHandler(
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
        public async Task<List<SystemConfigView>> Handle(
            FetchAllSystemConfigRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SystemConfigs
               .WhereWhenNotEmpty(request.Type, c => c.Type == request.Type)
               .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)
               .ApplyLimitConstraint(request)
               .ProjectTo<SystemConfigView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
