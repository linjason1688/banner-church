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
using App.Application.Managements.SystemConfigs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.FindSystemConfig
{
    /// <summary>
    /// 取得  SystemConfig 單筆明細
    /// </summary>

    public class FindSystemConfigRequest 
        : IRequest<SystemConfigView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSystemConfigRequestHandler 
        : IRequestHandler<FindSystemConfigRequest, SystemConfigView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSystemConfigRequestHandler(
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
        public async Task<SystemConfigView> Handle(
            FindSystemConfigRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SystemConfigs
               .Where(e => e.Id == request.Id)
               .ProjectTo<SystemConfigView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
