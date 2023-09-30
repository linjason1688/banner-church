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
using App.Application.Managements.SecRoles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SecRoles.Queries.QuerySecRole
{
    /// <summary>
    /// 分頁查詢 SecRole
    /// </summary>

    public class QuerySecRoleRequest 
        : PageableQuery, IRequest<Page<SecRoleView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 SecRole
    /// </summary>
    public class QuerySecRoleRequestHandler 
        : IRequestHandler<QuerySecRoleRequest, Page<SecRoleView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QuerySecRoleRequestHandler(
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
        public async Task<Page<SecRoleView>> Handle(
            QuerySecRoleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SecRoles
               .ProjectTo<SecRoleView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
