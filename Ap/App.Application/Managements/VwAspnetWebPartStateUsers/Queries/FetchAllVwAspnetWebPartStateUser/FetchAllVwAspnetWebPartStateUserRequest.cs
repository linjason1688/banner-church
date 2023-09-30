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
using App.Application.Managements.VwAspnetWebPartStateUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Queries.FetchAllVwAspnetWebPartStateUser
{
    /// <summary>
    /// 查詢  VwAspnetWebPartStateUser 所有資料
    /// </summary>

    public class FetchAllVwAspnetWebPartStateUserRequest 
        : IRequest<List<VwAspnetWebPartStateUserView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetWebPartStateUserHandler 
        : IRequestHandler<FetchAllVwAspnetWebPartStateUserRequest, List<VwAspnetWebPartStateUserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllVwAspnetWebPartStateUserHandler(
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
        public async Task<List<VwAspnetWebPartStateUserView>> Handle(
            FetchAllVwAspnetWebPartStateUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetWebPartStateUsers
               .ApplyLimitConstraint(request)
               .ProjectTo<VwAspnetWebPartStateUserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
