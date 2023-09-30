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
using App.Application.Managements.Pastorals.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FetchAllPastoral
{
    /// <summary>
    /// 查詢  Pastoral 所有資料
    /// </summary>

    public class FetchAllPastoralRequest
        : IRequest<List<PastoralView>>, ILimitedFetch
    {
        /// <inheritdoc />

        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPastoralHandler
        : IRequestHandler<FetchAllPastoralRequest, List<PastoralView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllPastoralHandler(
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
        public async Task<List<PastoralView>> Handle(
            FetchAllPastoralRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await this.appDbContext
               .Pastorals
               .ApplyLimitConstraint(request)
               .ProjectTo<PastoralView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            foreach (var obj in result)
            {
                obj.SubCounter = await this.appDbContext.Pastorals.Where(c => c.UpperPastoralId == obj.Id).CountAsync();
            }

            return result;

        }
    }
}
