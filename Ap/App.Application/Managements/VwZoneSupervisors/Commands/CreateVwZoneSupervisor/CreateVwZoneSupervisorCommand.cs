#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwZoneSupervisors.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Commands.CreateVwZoneSupervisor
{
    /// <summary>
    /// 建立 VwZoneSupervisor
    /// </summary>

    public class CreateVwZoneSupervisorCommand :  VwZoneSupervisorBase, IRequest<VwZoneSupervisorView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwZoneSupervisorCommandHandler : IRequestHandler<CreateVwZoneSupervisorCommand, VwZoneSupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwZoneSupervisorCommandHandler(
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
        public async Task<VwZoneSupervisorView> Handle(
            CreateVwZoneSupervisorCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwZoneSupervisor>(command);

            await this.appDbContext.VwZoneSupervisors.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwZoneSupervisorView>(entity);
        }
    }
}
