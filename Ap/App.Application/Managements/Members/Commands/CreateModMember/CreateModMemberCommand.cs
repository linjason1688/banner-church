#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Managements.Members.ModMembers.Dtos;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;

#endregion

namespace App.Application.Managements.Members.Commands.CreateModMember
{
    /// <summary>
    /// 建立 ModMember
    /// </summary>

    public class CreateModMemberCommand :  ModMemberBase, IRequest<ModMemberView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberCommandHandler : IRequestHandler<CreateModMemberCommand, ModMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberCommandHandler(
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
            CreateModMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMember>(command);

            await this.appDbContext.ModMembers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberView>(entity);
        }
    }
}
