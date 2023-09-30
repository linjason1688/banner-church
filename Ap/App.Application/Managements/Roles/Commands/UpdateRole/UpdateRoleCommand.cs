#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping;
using App.Application.Managements.Roles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Roles.Commands.UpdateRole
{
    /// <summary>
    /// 更新  Role
    /// </summary>

    public class UpdateRoleCommand : RoleBase,IRequest<RoleView>
    {
    
        public Guid? Id { get; set; }
        /// <summary>
        /// 角色與功能Menu列表
        /// </summary>
        public List<CreateRolePrivilegeMappingCommand> RolePrivilegeList { get; set; } = new();
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateRoleCommandHandler(
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
        public async Task<RoleView> Handle(
            UpdateRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.Roles.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RoleView>(entity);
        }
    }
}
