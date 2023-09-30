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
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Queries.FindMinistryScheduleDetail
{
    /// <summary>
    /// 取得  MinistryScheduleDetail 單筆明細
    /// </summary>

    public class FindMinistryScheduleDetailRequest 
        : IRequest<MinistryScheduleDetailView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryScheduleDetailRequestHandler 
        : IRequestHandler<FindMinistryScheduleDetailRequest, MinistryScheduleDetailView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryScheduleDetailRequestHandler(
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
        public async Task<MinistryScheduleDetailView> Handle(
            FindMinistryScheduleDetailRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryScheduleDetails
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryScheduleDetailView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
