#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Zoneleaders.ModZoneleaders.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.CreateModZoneleader
{
    /// <summary>
    /// 建立 ModZoneleader
    /// </summary>

    public class CreateModZoneleaderCommand :  ModZoneleaderBase, IRequest<ModZoneleaderView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModZoneleaderCommandHandler : IRequestHandler<CreateModZoneleaderCommand, ModZoneleaderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModZoneleaderCommandHandler(
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
        public async Task<ModZoneleaderView> Handle(
            CreateModZoneleaderCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModZoneleader>(command);

            await this.appDbContext.ModZoneleaders.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModZoneleaderView>(entity);
        }
    }
}
