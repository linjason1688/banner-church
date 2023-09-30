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
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Queries.FindRolePrivilegeMapping
{
    /// <summary>
    /// 取得  RolePrivilegeMapping 單筆明細
    /// </summary>

    public class FindRolePrivilegeMappingRequest 
        : IRequest<RolePrivilegeMappingView>
    {
    
        public Guid Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindRolePrivilegeMappingRequestHandler 
        : IRequestHandler<FindRolePrivilegeMappingRequest, RolePrivilegeMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindRolePrivilegeMappingRequestHandler(
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
        public async Task<RolePrivilegeMappingView> Handle(
            FindRolePrivilegeMappingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .RolePrivilegeMappings
               .Where(e => e.Id == request.Id)
               .ProjectTo<RolePrivilegeMappingView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
