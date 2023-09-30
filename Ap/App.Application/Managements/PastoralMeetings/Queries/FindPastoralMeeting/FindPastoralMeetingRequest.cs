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
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.PastoralMeetings.Queries.FindPastoralMeeting
{
    /// <summary>
    /// 取得  PastoralMeeting 單筆明細
    /// </summary>

    public class FindPastoralMeetingRequest 
        : IRequest<PastoralMeetingView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralMeetingRequestHandler 
        : IRequestHandler<FindPastoralMeetingRequest, PastoralMeetingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindPastoralMeetingRequestHandler(
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
        public async Task<PastoralMeetingView> Handle(
            FindPastoralMeetingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .PastoralMeetings
               .Where(e => e.Id == request.Id)
               .ProjectTo<PastoralMeetingView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
