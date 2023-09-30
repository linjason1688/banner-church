#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Members.ModMembers.Dtos;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.Members.ModMembers.Commands.UpdateModMember
{
    /// <summary>
    /// 更新  ModMember
    /// </summary>

    public class UpdateModMemberCommand : ModMemberBase,IRequest<ModMemberView>
    {
    
        //public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberCommandHandler : IRequestHandler<UpdateModMemberCommand, ModMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberCommandHandler(
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
        public async Task<ModMemberView> Handle(
            UpdateModMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModMembers.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberView>(entity);
        }
    }
}
