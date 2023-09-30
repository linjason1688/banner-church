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
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.FetchAllShoppingCart
{
    /// <summary>
    /// 查詢  ShoppingCart 所有資料
    /// </summary>

    public class FetchAllShoppingCartRequest 
        : IRequest<List<ShoppingCartView>>, ILimitedFetch
    {
        /// <summary>
        /// 用戶ID
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// 課程ID
        /// </summary>
        public long? CourseId { get; set; }
        /// <inheritdoc />
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllShoppingCartHandler 
        : IRequestHandler<FetchAllShoppingCartRequest, List<ShoppingCartView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllShoppingCartHandler(
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
        public async Task<List<ShoppingCartView>> Handle(
            FetchAllShoppingCartRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ShoppingCarts
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)
               .WhereWhen(Convert.ToInt64(request.CourseId) > 0, c => c.CourseId == request.CourseId)
               .ApplyLimitConstraint(request)
               .ProjectTo<ShoppingCartView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
