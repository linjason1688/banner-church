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
using App.Application.Managements.Arealeaders.ModArealeaders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Queries.FetchAllModArealeader
{
    /// <summary>
    /// 查詢  ModArealeader 所有資料
    /// </summary>

    public class FetchAllModArealeaderRequest 
        : IRequest<List<ModArealeaderView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModArealeaderHandler 
        : IRequestHandler<FetchAllModArealeaderRequest, List<ModArealeaderView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModArealeaderHandler(
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
        public async Task<List<ModArealeaderView>> Handle(
            FetchAllModArealeaderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModArealeaders
               .ApplyLimitConstraint(request)
               .ProjectTo<ModArealeaderView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
