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
using App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Queries.FindModCampaignSpday
{
    /// <summary>
    /// 取得  ModCampaignSpday 單筆明細
    /// </summary>

    public class FindModCampaignSpdayRequest 
        : IRequest<ModCampaignSpdayView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignSpdayRequestHandler 
        : IRequestHandler<FindModCampaignSpdayRequest, ModCampaignSpdayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModCampaignSpdayRequestHandler(
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
        public async Task<ModCampaignSpdayView> Handle(
            FindModCampaignSpdayRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModCampaignSpdays
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModCampaignSpdayView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
