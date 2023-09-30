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
using App.Application.$BaseNamespace$$Feature$.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Queries.FetchAll$Target$
{
    /// <summary>
    /// 查詢  $Target$ 所有資料
    /// </summary>

    public class FetchAll$Target$Request 
        : IRequest<List<$Target$View>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAll$Target$Handler 
        : IRequestHandler<FetchAll$Target$Request, List<$Target$View>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAll$Target$Handler(
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
        public async Task<List<$Target$View>> Handle(
            FetchAll$Target$Request request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .$Feature$
               .ApplyLimitConstraint(request)
               .ProjectTo<$Target$View>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
