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
using App.Application.Managements.MeetingPoints.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MeetingPoints.Queries.FindMeetingPoint
{
    /// <summary>
    /// 取得  MeetingPoint 單筆明細
    /// </summary>

    public class FindMeetingPointRequest 
        : IRequest<MeetingPointView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMeetingPointRequestHandler 
        : IRequestHandler<FindMeetingPointRequest, MeetingPointView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMeetingPointRequestHandler(
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
        public async Task<MeetingPointView> Handle(
            FindMeetingPointRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MeetingPoints
               .Where(e => e.Id == request.Id)
               .ProjectTo<MeetingPointView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
