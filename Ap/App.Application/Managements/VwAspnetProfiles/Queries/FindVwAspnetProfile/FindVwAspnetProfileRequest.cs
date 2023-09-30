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
using App.Application.Managements.VwAspnetProfiles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Queries.FindVwAspnetProfile
{
    /// <summary>
    /// 取得  VwAspnetProfile 單筆明細
    /// </summary>

    public class FindVwAspnetProfileRequest 
        : IRequest<VwAspnetProfileView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetProfileRequestHandler 
        : IRequestHandler<FindVwAspnetProfileRequest, VwAspnetProfileView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwAspnetProfileRequestHandler(
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
        public async Task<VwAspnetProfileView> Handle(
            FindVwAspnetProfileRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetProfiles
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwAspnetProfileView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
