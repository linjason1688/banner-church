#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Commands.DeleteSysAdminPermission
{
    /// <summary>
    /// 刪除  SysAdminPermission
    /// </summary>

    public class DeleteSysAdminPermissionCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysAdminPermissionCommandHandler : IRequestHandler<DeleteSysAdminPermissionCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteSysAdminPermissionCommandHandler(
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
        public async Task<Unit> Handle(
            DeleteSysAdminPermissionCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.SysAdminPermissions.RemoveAsync(
                new SysAdminPermission()
                {
                    //Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
