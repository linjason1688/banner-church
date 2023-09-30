#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAreaSupervisors.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Commands.CreateVwAreaSupervisor
{
    /// <summary>
    /// 建立 VwAreaSupervisor
    /// </summary>

    public class CreateVwAreaSupervisorCommand :  VwAreaSupervisorBase, IRequest<VwAreaSupervisorView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAreaSupervisorCommandHandler : IRequestHandler<CreateVwAreaSupervisorCommand, VwAreaSupervisorView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAreaSupervisorCommandHandler(
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
        public async Task<VwAreaSupervisorView> Handle(
            CreateVwAreaSupervisorCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAreaSupervisor>(command);

            await this.appDbContext.VwAreaSupervisors.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAreaSupervisorView>(entity);
        }
    }
}
