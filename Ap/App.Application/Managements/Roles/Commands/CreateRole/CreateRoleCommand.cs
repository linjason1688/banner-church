#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.Roles.Commands.CreateRole
{
    /// <summary>
    /// 建立 Role
    /// </summary>

    public class CreateRoleCommand :  RoleBase, IRequest<RoleView>
    {
        /// <summary>
        /// 角色與功能Menu列表
        /// </summary>
        public List<CreateRolePrivilegeMappingCommand> RolePrivilegeList { get; set; } = new();
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateRoleCommandHandler(
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
            CreateRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Role>(command);

            await this.appDbContext.Roles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RoleView>(entity);
        }
    }
}
