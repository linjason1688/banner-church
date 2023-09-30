#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.VwPreOrders.Queries.QueryVwPreOrder
{
    /// <summary>
    /// 分頁查詢 VwPreOrder
    /// </summary>

    public class QueryVwPreOrderRequest 
        : PageableQuery, IRequest<Page<VwPreOrderView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 VwPreOrder
    /// </summary>
    public class QueryVwPreOrderRequestHandler 
        : IRequestHandler<QueryVwPreOrderRequest, Page<VwPreOrderView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryVwPreOrderRequestHandler(
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
        public async Task<Page<VwPreOrderView>> Handle(
            QueryVwPreOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwPreOrders
               .ProjectTo<VwPreOrderView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
