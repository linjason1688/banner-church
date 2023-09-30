#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Zones.ModZones.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Zones.ModZones.Commands.CreateModZone
{
    /// <summary>
    /// 建立 ModZone
    /// </summary>

    public class CreateModZoneCommand :  ModZoneBase, IRequest<ModZoneView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModZoneCommandHandler : IRequestHandler<CreateModZoneCommand, ModZoneView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModZoneCommandHandler(
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
        public async Task<ModZoneView> Handle(
            CreateModZoneCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModZone>(command);

            await this.appDbContext.ModZones.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModZoneView>(entity);
        }
    }
}
