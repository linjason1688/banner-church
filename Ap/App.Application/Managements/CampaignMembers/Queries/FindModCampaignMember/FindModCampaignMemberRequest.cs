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
using App.Application.Managements.CampaignMembers.ModCampaignMembers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Queries.FindModCampaignMember
{
    /// <summary>
    /// 取得  ModCampaignMember 單筆明細
    /// </summary>

    public class FindModCampaignMemberRequest 
        : IRequest<ModCampaignMemberView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignMemberRequestHandler 
        : IRequestHandler<FindModCampaignMemberRequest, ModCampaignMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModCampaignMemberRequestHandler(
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
        public async Task<ModCampaignMemberView> Handle(
            FindModCampaignMemberRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModCampaignMembers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<ModCampaignMemberView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
