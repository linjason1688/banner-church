#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.PatchRolePrivilegeMapping
{
    /// <summary>
    /// 更新  RolePrivilegeMapping
    /// </summary>
    public class PatchRolePrivilegeMappingCommand : RolePrivilegeMappingBase, IRequest<RolePrivilegeMappingView>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class PatchRolePrivilegeMappingCommandHandler : IRequestHandler<PatchRolePrivilegeMappingCommand, RolePrivilegeMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public PatchRolePrivilegeMappingCommandHandler(
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
            PatchRolePrivilegeMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.RolePrivilegeMappings.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RolePrivilegeMappingView>(entity);
        }
    }
}
