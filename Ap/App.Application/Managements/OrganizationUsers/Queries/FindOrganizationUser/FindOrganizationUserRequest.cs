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
using App.Application.Managements.OrganizationUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.OrganizationUsers.Queries.FindOrganizationUser
{
    /// <summary>
    /// 取得  OrganizationUser 單筆明細
    /// </summary>

    public class FindOrganizationUserRequest 
        : IRequest<OrganizationUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindOrganizationUserRequestHandler 
        : IRequestHandler<FindOrganizationUserRequest, OrganizationUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindOrganizationUserRequestHandler(
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
        public async Task<OrganizationUserView> Handle(
            FindOrganizationUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .OrganizationUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<OrganizationUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
