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
using App.Application.Managements.VwZoneSupervisors.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Queries.FindVwZoneSupervisor
{
    /// <summary>
    /// 取得  VwZoneSupervisor 單筆明細
    /// </summary>

    public class FindVwZoneSupervisorRequest 
        : IRequest<VwZoneSupervisorView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwZoneSupervisorRequestHandler 
        : IRequestHandler<FindVwZoneSupervisorRequest, VwZoneSupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwZoneSupervisorRequestHandler(
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
        public async Task<VwZoneSupervisorView> Handle(
            FindVwZoneSupervisorRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwZoneSupervisors
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwZoneSupervisorView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
