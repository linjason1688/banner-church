#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.RoleUserMappings.Dtos;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.PatchRoleUserMapping
{
    /// <summary>
    /// 更新  RoleUserMapping
    /// </summary>
    public class PatchRoleUserMappingCommand : RoleUserMappingBase, IRequest<RoleUserMappingView>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class PatchRoleUserMappingCommandHandler : IRequestHandler<PatchRoleUserMappingCommand, RoleUserMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public PatchRoleUserMappingCommandHandler(
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
        public async Task<RoleUserMappingView> Handle(
            PatchRoleUserMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.RoleUserMappings.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RoleUserMappingView>(entity);
        }
    }
}
