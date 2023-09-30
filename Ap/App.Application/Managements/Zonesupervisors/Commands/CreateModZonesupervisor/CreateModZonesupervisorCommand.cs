#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Zonesupervisors.ModZonesupervisors.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.CreateModZonesupervisor
{
    /// <summary>
    /// 建立 ModZonesupervisor
    /// </summary>

    public class CreateModZonesupervisorCommand :  ModZonesupervisorBase, IRequest<ModZonesupervisorView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModZonesupervisorCommandHandler : IRequestHandler<CreateModZonesupervisorCommand, ModZonesupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModZonesupervisorCommandHandler(
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
        public async Task<ModZonesupervisorView> Handle(
            CreateModZonesupervisorCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModZonesupervisor>(command);

            await this.appDbContext.ModZonesupervisors.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModZonesupervisorView>(entity);
        }
    }
}
