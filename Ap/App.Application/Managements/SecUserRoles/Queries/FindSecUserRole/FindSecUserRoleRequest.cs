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
using App.Application.Managements.SecUserRoles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SecUserRoles.Queries.FindSecUserRole
{
    /// <summary>
    /// 取得  SecUserRole 單筆明細
    /// </summary>

    public class FindSecUserRoleRequest 
        : IRequest<SecUserRoleView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSecUserRoleRequestHandler 
        : IRequestHandler<FindSecUserRoleRequest, SecUserRoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSecUserRoleRequestHandler(
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
        public async Task<SecUserRoleView> Handle(
            FindSecUserRoleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SecUserRoles
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SecUserRoleView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
