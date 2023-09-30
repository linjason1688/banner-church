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
using App.Application.Managements.AspnetPersonalizationPerUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Queries.FindAspnetPersonalizationPerUser
{
    /// <summary>
    /// 取得  AspnetPersonalizationPerUser 單筆明細
    /// </summary>

    public class FindAspnetPersonalizationPerUserRequest 
        : IRequest<AspnetPersonalizationPerUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetPersonalizationPerUserRequestHandler 
        : IRequestHandler<FindAspnetPersonalizationPerUserRequest, AspnetPersonalizationPerUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindAspnetPersonalizationPerUserRequestHandler(
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
        public async Task<AspnetPersonalizationPerUserView> Handle(
            FindAspnetPersonalizationPerUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetPersonalizationPerUsers
               .Where(e => e.Id.ToString() == request.Id.ToString())
               .ProjectTo<AspnetPersonalizationPerUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
