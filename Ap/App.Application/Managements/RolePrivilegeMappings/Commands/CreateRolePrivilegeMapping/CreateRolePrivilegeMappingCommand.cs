#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping
{
    /// <summary>
    /// 建立 RolePrivilegeMapping
    /// </summary>

    public class CreateRolePrivilegeMappingCommand :  RolePrivilegeMappingBase, IRequest<RolePrivilegeMappingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateRolePrivilegeMappingCommandHandler : IRequestHandler<CreateRolePrivilegeMappingCommand, RolePrivilegeMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateRolePrivilegeMappingCommandHandler(
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
        public async Task<RolePrivilegeMappingView> Handle(
            CreateRolePrivilegeMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<RolePrivilegeMapping>(command);

            await this.appDbContext.RolePrivilegeMappings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RolePrivilegeMappingView>(entity);
        }
    }
}
