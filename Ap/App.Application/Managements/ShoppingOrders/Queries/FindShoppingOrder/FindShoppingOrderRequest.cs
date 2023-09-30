#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ShoppingOrders.Queries.FindShoppingOrder
{
    /// <summary>
    /// 取得  ShoppingOrder 單筆明細
    /// </summary>

    public class FindShoppingOrderRequest 
        : IRequest<ShoppingOrderView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingOrderRequestHandler 
        : IRequestHandler<FindShoppingOrderRequest, ShoppingOrderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindShoppingOrderRequestHandler(
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
        public async Task<ShoppingOrderView> Handle(
            FindShoppingOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ShoppingOrders
               .Where(e => e.Id == request.Id)
               .ProjectTo<ShoppingOrderView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
