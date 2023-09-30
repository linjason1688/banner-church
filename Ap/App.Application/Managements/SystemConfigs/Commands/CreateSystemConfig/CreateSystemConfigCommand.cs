#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SystemConfigs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SystemConfigs.Commands.CreateSystemConfig
{
    /// <summary>
    /// 建立 SystemConfig
    /// </summary>

    public class CreateSystemConfigCommand :  SystemConfigBase, IRequest<SystemConfigView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSystemConfigCommandHandler : IRequestHandler<CreateSystemConfigCommand, SystemConfigView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSystemConfigCommandHandler(
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
        public async Task<SystemConfigView> Handle(
            CreateSystemConfigCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SystemConfig>(command);

            await this.appDbContext.SystemConfigs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SystemConfigView>(entity);
        }
    }
}
