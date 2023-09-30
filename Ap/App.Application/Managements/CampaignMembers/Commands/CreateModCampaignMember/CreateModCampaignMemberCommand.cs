#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CampaignMembers.ModCampaignMembers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.CreateModCampaignMember
{
    /// <summary>
    /// 建立 ModCampaignMember
    /// </summary>

    public class CreateModCampaignMemberCommand :  ModCampaignMemberBase, IRequest<ModCampaignMemberView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModCampaignMemberCommandHandler : IRequestHandler<CreateModCampaignMemberCommand, ModCampaignMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModCampaignMemberCommandHandler(
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
            CreateModCampaignMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModCampaignMember>(command);

            await this.appDbContext.ModCampaignMembers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModCampaignMemberView>(entity);
        }
    }
}
