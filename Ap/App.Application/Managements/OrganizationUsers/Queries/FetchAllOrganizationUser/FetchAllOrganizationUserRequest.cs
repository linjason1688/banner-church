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
using App.Application.Managements.OrganizationUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.OrganizationUsers.Queries.FetchAllOrganizationUser
{
    /// <summary>
    /// 查詢  OrganizationUser 所有資料
    /// </summary>

    public class FetchAllOrganizationUserRequest 
        : IRequest<List<OrganizationUserView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }

        public long? OrganizationId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllOrganizationUserHandler 
        : IRequestHandler<FetchAllOrganizationUserRequest, List<OrganizationUserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllOrganizationUserHandler(
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
        public async Task<List<OrganizationUserView>> Handle(
            FetchAllOrganizationUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .OrganizationUsers
               .WhereWhen(request.OrganizationId.HasValue, c=>c.OrganizationId == request.OrganizationId)
               .ApplyLimitConstraint(request)
               .ProjectTo<OrganizationUserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
