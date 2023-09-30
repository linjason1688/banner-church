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
using App.Application.Managements.SysAdminPermissions.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Queries.FetchAllSysAdminPermission
{
    /// <summary>
    /// 查詢  SysAdminPermission 所有資料
    /// </summary>

    public class FetchAllSysAdminPermissionRequest 
        : IRequest<List<SysAdminPermissionView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysAdminPermissionHandler 
        : IRequestHandler<FetchAllSysAdminPermissionRequest, List<SysAdminPermissionView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllSysAdminPermissionHandler(
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
        public async Task<List<SysAdminPermissionView>> Handle(
            FetchAllSysAdminPermissionRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysAdminPermissions
               .ApplyLimitConstraint(request)
               .ProjectTo<SysAdminPermissionView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
