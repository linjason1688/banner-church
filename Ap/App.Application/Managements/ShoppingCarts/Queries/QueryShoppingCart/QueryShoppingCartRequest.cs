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
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.QueryShoppingCart
{
    /// <summary>
    /// 分頁查詢 ShoppingCart
    /// </summary>

    public class QueryShoppingCartRequest 
        : PageableQuery, IRequest<Page<ShoppingCartView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }


        ///  <summary>
        ///數量
        /// </summary>
        public int Count { get; set; }
        ///  <summary>
        ///出席狀態 對應SystemConfig內Type=ShoppingCartStatus 0:新增 1已轉入訂單 2:逾期課程清單(無法轉訂單) 3:數量不足
        /// </summary>
        /// 
        public string ShoppingCartStatus { get; set; }

    }

    /// <summary>
    ///  分頁查詢 ShoppingCart
    /// </summary>
    public class QueryShoppingCartRequestHandler 
        : IRequestHandler<QueryShoppingCartRequest, Page<ShoppingCartView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryShoppingCartRequestHandler(
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
        public async Task<Page<ShoppingCartView>> Handle(
            QueryShoppingCartRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ShoppingCarts
                .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) ////購物車主檔
                 .WhereWhen(Convert.ToInt64(request.UserId) != 0, c => c.UserId == request.UserId) //User.Id
                  .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)
             
                .WhereWhenNotEmpty(request.Count.ToString(), c => c.Count == request.Count)//數量
                .WhereWhenNotEmpty(request.ShoppingCartStatus?.ToString(), c => c.ShoppingCartStatus == request.ShoppingCartStatus)//出席狀態 對應SystemConfig內Type=ShoppingCartStatus 0:新增 1已轉入訂單 2:逾期課程清單(無法轉訂單) 3:數量不足

               .ProjectTo<ShoppingCartView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
