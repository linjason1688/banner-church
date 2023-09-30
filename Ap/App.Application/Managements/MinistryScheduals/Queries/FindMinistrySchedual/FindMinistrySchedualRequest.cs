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
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.FindMinistrySchedule
{
    /// <summary>
    /// 取得  MinistrySchedule 單筆明細
    /// </summary>

    public class FindMinistryScheduleRequest 
        : IRequest<MinistryScheduleView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryScheduleRequestHandler 
        : IRequestHandler<FindMinistryScheduleRequest, MinistryScheduleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryScheduleRequestHandler(
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
        public async Task<MinistryScheduleView> Handle(
            FindMinistryScheduleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistrySchedules
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryScheduleView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
