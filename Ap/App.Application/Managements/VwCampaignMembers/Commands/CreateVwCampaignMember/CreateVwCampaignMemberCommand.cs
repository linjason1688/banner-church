#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwCampaignMembers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Commands.CreateVwCampaignMember
{
    /// <summary>
    /// 建立 VwCampaignMember
    /// </summary>

    public class CreateVwCampaignMemberCommand :  VwCampaignMemberBase, IRequest<VwCampaignMemberView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwCampaignMemberCommandHandler : IRequestHandler<CreateVwCampaignMemberCommand, VwCampaignMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwCampaignMemberCommandHandler(
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
            CreateVwCampaignMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwCampaignMember>(command);

            await this.appDbContext.VwCampaignMembers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwCampaignMemberView>(entity);
        }
    }
}
