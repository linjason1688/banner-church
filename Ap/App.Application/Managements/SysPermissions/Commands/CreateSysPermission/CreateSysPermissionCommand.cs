#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysPermissions.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysPermissions.Commands.CreateSysPermission
{
    /// <summary>
    /// 建立 SysPermission
    /// </summary>

    public class CreateSysPermissionCommand :  SysPermissionBase, IRequest<SysPermissionView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysPermissionCommandHandler : IRequestHandler<CreateSysPermissionCommand, SysPermissionView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysPermissionCommandHandler(
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
        public async Task<SysPermissionView> Handle(
            CreateSysPermissionCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysPermission>(command);

            await this.appDbContext.SysPermissions.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysPermissionView>(entity);
        }
    }
}
