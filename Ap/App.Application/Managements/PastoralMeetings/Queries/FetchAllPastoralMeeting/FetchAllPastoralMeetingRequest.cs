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
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.PastoralMeetings.Queries.FetchAllPastoralMeeting
{
    /// <summary>
    /// 查詢  PastoralMeeting 所有資料
    /// </summary>

    public class FetchAllPastoralMeetingRequest 
        : IRequest<List<PastoralMeetingView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPastoralMeetingHandler 
        : IRequestHandler<FetchAllPastoralMeetingRequest, List<PastoralMeetingView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllPastoralMeetingHandler(
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
        public async Task<List<PastoralMeetingView>> Handle(
            FetchAllPastoralMeetingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .PastoralMeetings
               .ApplyLimitConstraint(request)
               .ProjectTo<PastoralMeetingView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
