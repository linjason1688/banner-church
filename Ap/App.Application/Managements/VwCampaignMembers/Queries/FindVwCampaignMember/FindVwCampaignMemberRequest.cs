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
using App.Application.Managements.VwCampaignMembers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Queries.FindVwCampaignMember
{
    /// <summary>
    /// 取得  VwCampaignMember 單筆明細
    /// </summary>

    public class FindVwCampaignMemberRequest 
        : IRequest<VwCampaignMemberView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwCampaignMemberRequestHandler 
        : IRequestHandler<FindVwCampaignMemberRequest, VwCampaignMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwCampaignMemberRequestHandler(
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
        public async Task<VwCampaignMemberView> Handle(
            FindVwCampaignMemberRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwCampaignMembers
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwCampaignMemberView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
