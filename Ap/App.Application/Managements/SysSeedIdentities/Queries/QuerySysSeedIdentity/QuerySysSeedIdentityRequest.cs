#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysSeedIdentities.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Queries.QuerySysSeedIdentity
{
    /// <summary>
    /// 分頁查詢 SysSeedIdentity
    /// </summary>

    public class QuerySysSeedIdentityRequest 
        : PageableQuery, IRequest<Page<SysSeedIdentityView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 SysSeedIdentity
    /// </summary>
    public class QuerySysSeedIdentityRequestHandler 
        : IRequestHandler<QuerySysSeedIdentityRequest, Page<SysSeedIdentityView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QuerySysSeedIdentityRequestHandler(
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
        public async Task<Page<SysSeedIdentityView>> Handle(
            QuerySysSeedIdentityRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysSeedIdentities
               .ProjectTo<SysSeedIdentityView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
