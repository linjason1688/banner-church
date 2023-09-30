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
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.FindShoppingCart
{
    /// <summary>
    /// 取得  ShoppingCart 單筆明細
    /// </summary>

    public class FindShoppingCartRequest 
        : IRequest<ShoppingCartView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingCartRequestHandler 
        : IRequestHandler<FindShoppingCartRequest, ShoppingCartView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindShoppingCartRequestHandler(
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
        public async Task<ShoppingCartView> Handle(
            FindShoppingCartRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ShoppingCarts
               .Where(e => e.Id == request.Id)
               .ProjectTo<ShoppingCartView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
