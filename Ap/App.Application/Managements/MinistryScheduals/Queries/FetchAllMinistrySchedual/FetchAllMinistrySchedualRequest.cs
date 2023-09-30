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
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.FetchAllMinistrySchedule
{
    /// <summary>
    /// 查詢  MinistrySchedule 所有資料
    /// </summary>

    public class FetchAllMinistryScheduleRequest 
        : IRequest<List<MinistryScheduleView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryScheduleHandler 
        : IRequestHandler<FetchAllMinistryScheduleRequest, List<MinistryScheduleView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllMinistryScheduleHandler(
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
        public async Task<List<MinistryScheduleView>> Handle(
            FetchAllMinistryScheduleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistrySchedules
               .ApplyLimitConstraint(request)
               .ProjectTo<MinistryScheduleView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
