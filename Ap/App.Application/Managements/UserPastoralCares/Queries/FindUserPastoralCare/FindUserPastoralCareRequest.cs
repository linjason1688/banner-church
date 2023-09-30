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
using App.Application.Managements.UserPastoralCares.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserPastoralCares.Queries.FindUserPastoralCare
{
    /// <summary>
    /// 取得  UserPastoralCare 單筆明細
    /// </summary>

    public class FindUserPastoralCareRequest 
        : IRequest<UserPastoralCareView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserPastoralCareRequestHandler 
        : IRequestHandler<FindUserPastoralCareRequest, UserPastoralCareView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserPastoralCareRequestHandler(
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
        public async Task<UserPastoralCareView> Handle(
            FindUserPastoralCareRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserPastoralCares
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserPastoralCareView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
