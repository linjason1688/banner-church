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
using App.Application.Managements.ShoppingOrderDetails.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Queries.QueryShoppingOrderDetail
{
    /// <summary>
    /// 分頁查詢 ShoppingOrderDetail
    /// </summary>

    public class QueryShoppingOrderDetailRequest 
        : PageableQuery, IRequest<Page<ShoppingOrderDetailView>>
    {
        ///  <summary>
        ///訂單明細主檔Id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///ShoppingOrder.Id
        /// </summary>
        public long ShoppingOrderId { get; set; }
        ///  <summary>
        ///Course.Id 課程Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///單價
        /// </summary>
        public int Price { get; set; }
        ///  <summary>
        ///購買數量
        /// </summary>
        public int Count { get; set; }
        ///  <summary>
        ///總金額
        /// </summary>
        public int Amount { get; set; }
        ///  <summary>
        ///付款方式 對應SystemConfig內Type=OrderDetailStatus 0:尚未付款 1:已付款 2:付款完成 3:退款申請 4:退款完成
        /// </summary>
        public string OrderDetailStatus { get; set; }


        ///  <summary>
        ///UserId
        /// </summary>
        public long UserId { get; set; }

    }

    /// <summary>
    ///  分頁查詢 ShoppingOrderDetail
    /// </summary>
    public class QueryShoppingOrderDetailRequestHandler 
        : IRequestHandler<QueryShoppingOrderDetailRequest, Page<ShoppingOrderDetailView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryShoppingOrderDetailRequestHandler(
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
        public async Task<Page<ShoppingOrderDetailView>> Handle(
            QueryShoppingOrderDetailRequest request,
            CancellationToken cancellationToken
        )
        {



            var lst = this.appDbContext.ShoppingOrders
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId);//User.Id



            return await this.appDbContext
               .ShoppingOrderDetails
                //串上UserId 過濾ShoppingOrder的資訊
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => lst.Select(c => c.Id).Contains(c.ShoppingOrderId))             
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)////訂單明細主檔
                .WhereWhen(Convert.ToInt64(request.ShoppingOrderId ) != 0, c => c.ShoppingOrderId == request.ShoppingOrderId )//訂單主檔Id
                 .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)//Course.Id

                .WhereWhen(request.Price.ToString()!="0", c => c.Price == request.Price)//單價
                .WhereWhen(request.Count.ToString() != "0", c => c.Count == request.Count)//購買數量
                .WhereWhen(request.Amount.ToString() != "0", c => c.Amount == request.Amount)//總金額
                .WhereWhenNotEmpty(request.OrderDetailStatus?.ToString(), c => c.OrderDetailStatus == request.OrderDetailStatus)//付款方式 對應SystemConfig內Type=OrderDetailStatus 0:尚未付款 1:已付款 2:付款完成 3:退款申請 4:退款完成

               .ProjectTo<ShoppingOrderDetailView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
