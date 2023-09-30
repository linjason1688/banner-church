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
using App.Application.Managements.VwMeetingMembers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Queries.FindVwMeetingMember
{
    /// <summary>
    /// 取得  VwMeetingMember 單筆明細
    /// </summary>

    public class FindVwMeetingMemberRequest 
        : IRequest<VwMeetingMemberView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwMeetingMemberRequestHandler 
        : IRequestHandler<FindVwMeetingMemberRequest, VwMeetingMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwMeetingMemberRequestHandler(
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
        public async Task<VwMeetingMemberView> Handle(
            FindVwMeetingMemberRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMeetingMembers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwMeetingMemberView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
