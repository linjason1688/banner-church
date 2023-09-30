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
using App.Application.Managements.AspnetProfiles.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetProfiles.Queries.FetchAllAspnetProfile
{
    /// <summary>
    /// 查詢  AspnetProfile 所有資料
    /// </summary>

    public class FetchAllAspnetProfileRequest 
        : IRequest<List<AspnetProfileView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetProfileHandler 
        : IRequestHandler<FetchAllAspnetProfileRequest, List<AspnetProfileView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllAspnetProfileHandler(
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
        public async Task<List<AspnetProfileView>> Handle(
            FetchAllAspnetProfileRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetProfiles
               .ApplyLimitConstraint(request)
               .ProjectTo<AspnetProfileView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
