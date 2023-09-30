#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.FetchAllRoleUserMapping
{
    /// <summary>
    /// 查詢  RoleUserMapping 所有資料
    /// </summary>

    public class FetchAllRoleUserMappingRequest 
        : IRequest<List<RoleUserMappingView>>, ILimitedFetch
    {
        /// <inheritdoc />
        public Guid? Id { get; set; }
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllRoleUserMappingHandler 
        : IRequestHandler<FetchAllRoleUserMappingRequest, List<RoleUserMappingView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllRoleUserMappingHandler(
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
        public async Task<List<RoleUserMappingView>> Handle(
            FetchAllRoleUserMappingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .RoleUserMappings
               .WhereWhen(request.Id.HasValue, c => c.Id == request.Id.Value)
               .ApplyLimitConstraint(request)
               .ProjectTo<RoleUserMappingView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
