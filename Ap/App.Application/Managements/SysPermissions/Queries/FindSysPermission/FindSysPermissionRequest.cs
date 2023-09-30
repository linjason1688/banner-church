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
using App.Application.Managements.SysPermissions.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysPermissions.Queries.FindSysPermission
{
    /// <summary>
    /// 取得  SysPermission 單筆明細
    /// </summary>

    public class FindSysPermissionRequest 
        : IRequest<SysPermissionView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSysPermissionRequestHandler 
        : IRequestHandler<FindSysPermissionRequest, SysPermissionView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSysPermissionRequestHandler(
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
        public async Task<SysPermissionView> Handle(
            FindSysPermissionRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysPermissions
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SysPermissionView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
