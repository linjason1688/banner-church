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
using App.Application.Managements.VwGroups.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwGroups.Queries.FindVwGroup
{
    /// <summary>
    /// 取得  VwGroup 單筆明細
    /// </summary>

    public class FindVwGroupRequest 
        : IRequest<VwGroupView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwGroupRequestHandler 
        : IRequestHandler<FindVwGroupRequest, VwGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwGroupRequestHandler(
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
        public async Task<VwGroupView> Handle(
            FindVwGroupRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwGroups
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwGroupView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}