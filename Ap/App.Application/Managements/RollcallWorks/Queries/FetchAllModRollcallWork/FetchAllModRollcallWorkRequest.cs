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
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Queries.FetchAllModRollcallWork
{
    /// <summary>
    /// 查詢  ModRollcallWork 所有資料
    /// </summary>

    public class FetchAllModRollcallWorkRequest 
        : IRequest<List<ModRollcallWorkView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModRollcallWorkHandler 
        : IRequestHandler<FetchAllModRollcallWorkRequest, List<ModRollcallWorkView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModRollcallWorkHandler(
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
        public async Task<List<ModRollcallWorkView>> Handle(
            FetchAllModRollcallWorkRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModRollcallWorks
               .ApplyLimitConstraint(request)
               .ProjectTo<ModRollcallWorkView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
