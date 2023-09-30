#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Members.ModMembers.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

#endregion

namespace App.Application.Managements.Members.ModMembers.Queries.FetchAllModMember
{
    /// <summary>
    /// 查詢  ModMember 所有資料
    /// </summary>

    public class FetchAllModMemberRequest 
        : IRequest<List<ModMemberView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberHandler 
        : IRequestHandler<FetchAllModMemberRequest, List<ModMemberView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModMemberHandler(
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
        public async Task<List<ModMemberView>> Handle(
            FetchAllModMemberRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModMembers
               .ApplyLimitConstraint(request)
               .ProjectTo<ModMemberView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
