#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.FindMinistryRespUser
{
    /// <summary>
    /// 取得  MinistryRespUser 單筆明細
    /// </summary>

    public class FindMinistryRespUserRequest 
        : IRequest<MinistryRespUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryRespUserRequestHandler 
        : IRequestHandler<FindMinistryRespUserRequest, MinistryRespUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryRespUserRequestHandler(
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
        public async Task<MinistryRespUserView> Handle(
            FindMinistryRespUserRequest request,
            CancellationToken cancellationToken
        )
        {


            var result = await this.appDbContext
               .MinistryRespUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryRespUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);

            result.userView = await this.appDbContext.Users.Where(c => result.UserId == c.Id)
                                        .ProjectTo<UserView>(this.mapper.ConfigurationProvider)
                                        .FindOneAsync(cancellationToken);

            return result;
        }
    }
}
