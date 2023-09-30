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
using App.Application.Managements.AspnetPersonalizationAllUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Queries.FindAspnetPersonalizationAllUser
{
    /// <summary>
    /// 取得  AspnetPersonalizationAllUser 單筆明細
    /// </summary>

    public class FindAspnetPersonalizationAllUserRequest 
        : IRequest<AspnetPersonalizationAllUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetPersonalizationAllUserRequestHandler 
        : IRequestHandler<FindAspnetPersonalizationAllUserRequest, AspnetPersonalizationAllUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindAspnetPersonalizationAllUserRequestHandler(
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
        public async Task<AspnetPersonalizationAllUserView> Handle(
            FindAspnetPersonalizationAllUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetPersonalizationAllUsers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<AspnetPersonalizationAllUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
