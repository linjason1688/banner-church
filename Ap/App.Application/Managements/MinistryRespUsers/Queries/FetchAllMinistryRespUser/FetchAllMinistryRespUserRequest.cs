#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryRespUsers.Dtos;
using App.Application.Managements.Users.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.FetchAllMinistryRespUser
{
    /// <summary>
    /// 查詢  MinistryRespUser 所有資料
    /// </summary>

    public class FetchAllMinistryRespUserRequest 
        : IRequest<List<MinistryRespUserView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryRespUserHandler 
        : IRequestHandler<FetchAllMinistryRespUserRequest, List<MinistryRespUserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllMinistryRespUserHandler(
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
        public async Task<List<MinistryRespUserView>> Handle(
            FetchAllMinistryRespUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .MinistryRespUsers
               .ApplyLimitConstraint(request)
               .ProjectTo<MinistryRespUserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            var ids = result.Select(c => c.UserId).Distinct();

            var userLst = await this.appDbContext.Users.Where(c=>ids.Contains(c.Id))
                                    .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

            foreach(var obj in result)
            {
                obj.userView = userLst.FirstOrDefault(c => c.Id == obj.UserId);
            }

            return result;
        }
    }
}
