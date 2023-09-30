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

namespace App.Application.Managements.RolePrivilegeMappings.Commands.DeleteRolePrivilegeMapping
{
    /// <summary>
    /// 刪除  RolePrivilegeMapping
    /// </summary>

    public class DeleteRolePrivilegeMappingCommand : IRequest<Unit>
    {
    
        public Guid Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteRolePrivilegeMappingCommandHandler : IRequestHandler<DeleteRolePrivilegeMappingCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteRolePrivilegeMappingCommandHandler(
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
            DeleteRolePrivilegeMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.RolePrivilegeMappings.RemoveAsync(
                new RolePrivilegeMapping()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
