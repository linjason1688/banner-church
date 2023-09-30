#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Privileges.Dtos;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.Privileges.Commands.PatchPrivilege
{
    /// <summary>
    /// 更新  Privilege
    /// </summary>
    public class PatchPrivilegeCommand : PrivilegeBase, IRequest<PrivilegeView>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class PatchPrivilegeCommandHandler : IRequestHandler<PatchPrivilegeCommand, PrivilegeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public PatchPrivilegeCommandHandler(
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
        /// <Privileges></Privileges>
        public async Task<PrivilegeView> Handle(
            PatchPrivilegeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.Privileges.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<PrivilegeView>(entity);
        }
    }
}
