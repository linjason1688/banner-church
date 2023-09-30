#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.CreateModCampaignSpday
{
    /// <summary>
    /// 建立 ModCampaignSpday
    /// </summary>

    public class CreateModCampaignSpdayCommand :  ModCampaignSpdayBase, IRequest<ModCampaignSpdayView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModCampaignSpdayCommandHandler : IRequestHandler<CreateModCampaignSpdayCommand, ModCampaignSpdayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModCampaignSpdayCommandHandler(
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
            CreateModCampaignSpdayCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModCampaignSpday>(command);

            await this.appDbContext.ModCampaignSpdays.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModCampaignSpdayView>(entity);
        }
    }
}
