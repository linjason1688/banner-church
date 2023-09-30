#region

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Members.ModMembers.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

#endregion

namespace App.Application.Managements.Members.ModMembers.Queries.FindModMember
{
    /// <summary>
    /// 取得  ModMember 單筆明細
    /// </summary>

    public class FindModMemberRequest 
        : IRequest<ModMemberView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberRequestHandler 
        : IRequestHandler<FindModMemberRequest, ModMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModMemberRequestHandler(
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
            FindModMemberRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModMembers
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModMemberView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
