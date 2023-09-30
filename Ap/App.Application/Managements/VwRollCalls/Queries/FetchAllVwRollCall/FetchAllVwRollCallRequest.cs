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
using App.Application.Managements.VwRollCalls.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwRollCalls.Queries.FetchAllVwRollCall
{
    /// <summary>
    /// 查詢  VwRollCall 所有資料
    /// </summary>

    public class FetchAllVwRollCallRequest 
        : IRequest<List<VwRollCallView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwRollCallHandler 
        : IRequestHandler<FetchAllVwRollCallRequest, List<VwRollCallView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllVwRollCallHandler(
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
        public async Task<List<VwRollCallView>> Handle(
            FetchAllVwRollCallRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwRollCalls
               .ApplyLimitConstraint(request)
               .ProjectTo<VwRollCallView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
