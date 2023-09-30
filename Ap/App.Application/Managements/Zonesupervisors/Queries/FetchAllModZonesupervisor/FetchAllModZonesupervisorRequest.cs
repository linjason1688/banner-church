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
using App.Application.Managements.Zonesupervisors.ModZonesupervisors.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Queries.FetchAllModZonesupervisor
{
    /// <summary>
    /// 查詢  ModZonesupervisor 所有資料
    /// </summary>

    public class FetchAllModZonesupervisorRequest 
        : IRequest<List<ModZonesupervisorView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModZonesupervisorHandler 
        : IRequestHandler<FetchAllModZonesupervisorRequest, List<ModZonesupervisorView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModZonesupervisorHandler(
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
        public async Task<List<ModZonesupervisorView>> Handle(
            FetchAllModZonesupervisorRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModZonesupervisors
               .ApplyLimitConstraint(request)
               .ProjectTo<ModZonesupervisorView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
