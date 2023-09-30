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
using App.Application.Managements.VwPreOrders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwPreOrders.Queries.FetchAllVwPreOrder
{
    /// <summary>
    /// 查詢  VwPreOrder 所有資料
    /// </summary>

    public class FetchAllVwPreOrderRequest 
        : IRequest<List<VwPreOrderView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwPreOrderHandler 
        : IRequestHandler<FetchAllVwPreOrderRequest, List<VwPreOrderView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllVwPreOrderHandler(
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
        public async Task<List<VwPreOrderView>> Handle(
            FetchAllVwPreOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwPreOrders
               .ApplyLimitConstraint(request)
               .ProjectTo<VwPreOrderView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
