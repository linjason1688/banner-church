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
using App.Application.Managements.Campaigns.ModCampaigns.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Queries.FindModCampaign
{
    /// <summary>
    /// 取得  ModCampaign 單筆明細
    /// </summary>

    public class FindModCampaignRequest 
        : IRequest<ModCampaignView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignRequestHandler 
        : IRequestHandler<FindModCampaignRequest, ModCampaignView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModCampaignRequestHandler(
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
        public async Task<ModCampaignView> Handle(
            FindModCampaignRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModCampaigns
               .Where(e => e.Id.ToString() == request.Id.ToString())
               .ProjectTo<ModCampaignView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
