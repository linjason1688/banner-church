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
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Queries.QueryRolePrivilegeMapping
{
    /// <summary>
    /// 分頁查詢 RolePrivilegeMapping
    /// </summary>

    public class QueryRolePrivilegeMappingRequest
        : PageableQuery, IRequest<Page<RolePrivilegeMappingView>>
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Role Id
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Privilege Id
        /// </summary>
        public Guid? PrivilegeId { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 RolePrivilegeMapping
    /// </summary>
    public class QueryRolePrivilegeMappingRequestHandler
        : IRequestHandler<QueryRolePrivilegeMappingRequest, Page<RolePrivilegeMappingView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryRolePrivilegeMappingRequestHandler(
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
        public async Task<Page<RolePrivilegeMappingView>> Handle(
            QueryRolePrivilegeMappingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .RolePrivilegeMappings
               .WhereWhen(request.Id.HasValue, c => c.Id == request.Id.Value)
               .WhereWhen(request.RoleId.HasValue, c => c.RoleId == request.RoleId.Value)
               .WhereWhen(request.PrivilegeId.HasValue, c => c.RoleId == request.PrivilegeId.Value)
               .ProjectTo<RolePrivilegeMappingView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
