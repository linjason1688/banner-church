#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysPortals.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysPortals.Commands.CreateSysPortal
{
    /// <summary>
    /// 建立 SysPortal
    /// </summary>

    public class CreateSysPortalCommand :  SysPortalBase, IRequest<SysPortalView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysPortalCommandHandler : IRequestHandler<CreateSysPortalCommand, SysPortalView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysPortalCommandHandler(
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
        public async Task<SysPortalView> Handle(
            CreateSysPortalCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysPortal>(command);

            await this.appDbContext.SysPortals.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysPortalView>(entity);
        }
    }
}
