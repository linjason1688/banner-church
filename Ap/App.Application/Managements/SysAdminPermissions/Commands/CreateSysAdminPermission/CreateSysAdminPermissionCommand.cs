#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysAdminPermissions.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Commands.CreateSysAdminPermission
{
    /// <summary>
    /// 建立 SysAdminPermission
    /// </summary>

    public class CreateSysAdminPermissionCommand :  SysAdminPermissionBase, IRequest<SysAdminPermissionView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysAdminPermissionCommandHandler : IRequestHandler<CreateSysAdminPermissionCommand, SysAdminPermissionView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysAdminPermissionCommandHandler(
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
        public async Task<SysAdminPermissionView> Handle(
            CreateSysAdminPermissionCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysAdminPermission>(command);

            await this.appDbContext.SysAdminPermissions.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysAdminPermissionView>(entity);
        }
    }
}
