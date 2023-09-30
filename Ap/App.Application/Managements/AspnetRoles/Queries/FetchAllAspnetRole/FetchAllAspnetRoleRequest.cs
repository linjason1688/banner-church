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
using App.Application.Managements.AspnetRoles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetRoles.Queries.FetchAllAspnetRole
{
    /// <summary>
    /// 查詢  AspnetRole 所有資料
    /// </summary>

    public class FetchAllAspnetRoleRequest 
        : IRequest<List<AspnetRoleView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetRoleHandler 
        : IRequestHandler<FetchAllAspnetRoleRequest, List<AspnetRoleView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllAspnetRoleHandler(
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
        public async Task<List<AspnetRoleView>> Handle(
            FetchAllAspnetRoleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetRoles
               .ApplyLimitConstraint(request)
               .ProjectTo<AspnetRoleView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
