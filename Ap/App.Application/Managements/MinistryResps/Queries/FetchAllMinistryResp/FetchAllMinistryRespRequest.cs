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
using App.Application.Managements.MinistryResps.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.FetchAllMinistryResp
{
    /// <summary>
    /// 查詢  MinistryResp 所有資料
    /// </summary>
    public class FetchAllMinistryRespRequest
        : IRequest<List<MinistryRespView>>, ILimitedFetch
    {
        /// <inheritdoc />
        public int? Limit { get; set; }

        /// <summary>
        /// 事工團.Id
        /// </summary>
        public long? MinistryId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryRespHandler
        : IRequestHandler<FetchAllMinistryRespRequest, List<MinistryRespView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllMinistryRespHandler(
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
        public async Task<List<MinistryRespView>> Handle(
            FetchAllMinistryRespRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryResps
               .WhereWhen(Convert.ToInt64(request.MinistryId) != 0, c => c.MinistryId == request.MinistryId)
               .ApplyLimitConstraint(request)
               .ProjectTo<MinistryRespView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
