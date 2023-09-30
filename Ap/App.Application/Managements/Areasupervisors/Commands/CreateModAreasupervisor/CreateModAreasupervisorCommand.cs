#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Areasupervisors.ModAreasupervisors.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.CreateModAreasupervisor
{
    /// <summary>
    /// 建立 ModAreasupervisor
    /// </summary>

    public class CreateModAreasupervisorCommand :  ModAreasupervisorBase, IRequest<ModAreasupervisorView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModAreasupervisorCommandHandler : IRequestHandler<CreateModAreasupervisorCommand, ModAreasupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModAreasupervisorCommandHandler(
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
        public async Task<ModAreasupervisorView> Handle(
            CreateModAreasupervisorCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModAreasupervisor>(command);

            await this.appDbContext.ModAreasupervisors.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModAreasupervisorView>(entity);
        }
    }
}
