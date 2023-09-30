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
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.FindRoleUserMapping
{
    /// <summary>
    /// 取得  RoleUserMapping 單筆明細
    /// </summary>

    public class FindRoleUserMappingRequest 
        : IRequest<RoleUserMappingView>
    {
    
        public Guid Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindRoleUserMappingRequestHandler 
        : IRequestHandler<FindRoleUserMappingRequest, RoleUserMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindRoleUserMappingRequestHandler(
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
        public async Task<RoleUserMappingView> Handle(
            FindRoleUserMappingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .RoleUserMappings
               .Where(e => e.Id == request.Id)
               .ProjectTo<RoleUserMappingView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
