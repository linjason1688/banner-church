#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping;
using App.Application.Managements.Roles.Dtos;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.Roles.Commands.PatchRole
{
    /// <summary>
    /// 更新  Role
    /// </summary>
    public class PatchRoleCommand : RoleBase, IRequest<RoleView>
    {
        /// <summary>
        /// 角色與功能Menu列表
        /// </summary>
        public List<CreateRolePrivilegeMappingCommand> RolePrivilegeList { get; set; } = new();
    }

    /// <summary>
    /// 
    /// </summary>
    public class PatchRoleCommandHandler : IRequestHandler<PatchRoleCommand, RoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public PatchRoleCommandHandler(
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
        /// <Roles></Roles>
        public async Task<RoleView> Handle(
            PatchRoleCommand command,
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
