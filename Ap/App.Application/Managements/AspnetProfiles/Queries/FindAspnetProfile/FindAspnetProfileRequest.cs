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
using App.Application.Managements.AspnetProfiles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetProfiles.Queries.FindAspnetProfile
{
    /// <summary>
    /// 取得  AspnetProfile 單筆明細
    /// </summary>

    public class FindAspnetProfileRequest 
        : IRequest<AspnetProfileView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetProfileRequestHandler 
        : IRequestHandler<FindAspnetProfileRequest, AspnetProfileView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindAspnetProfileRequestHandler(
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
        public async Task<AspnetProfileView> Handle(
            FindAspnetProfileRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetProfiles
               //.Where(e => e.Id == request.Id)
               .ProjectTo<AspnetProfileView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
