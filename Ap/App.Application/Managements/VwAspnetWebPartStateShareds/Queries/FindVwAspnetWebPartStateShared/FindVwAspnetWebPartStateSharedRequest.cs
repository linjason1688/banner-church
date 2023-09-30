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
using App.Application.Managements.VwAspnetWebPartStateShareds.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Queries.FindVwAspnetWebPartStateShared
{
    /// <summary>
    /// 取得  VwAspnetWebPartStateShared 單筆明細
    /// </summary>

    public class FindVwAspnetWebPartStateSharedRequest 
        : IRequest<VwAspnetWebPartStateSharedView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetWebPartStateSharedRequestHandler 
        : IRequestHandler<FindVwAspnetWebPartStateSharedRequest, VwAspnetWebPartStateSharedView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwAspnetWebPartStateSharedRequestHandler(
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
        public async Task<VwAspnetWebPartStateSharedView> Handle(
            FindVwAspnetWebPartStateSharedRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetWebPartStateShareds
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwAspnetWebPartStateSharedView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
