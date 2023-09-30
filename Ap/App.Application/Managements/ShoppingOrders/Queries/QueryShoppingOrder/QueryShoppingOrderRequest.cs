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
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Courses.Dtos;
using App.Domain.Entities.Features;
using App.Application.Managements.ShoppingOrderDetails.Dtos;

#endregion

namespace App.Application.Managements.ShoppingOrders.Queries.QueryShoppingOrder
{
    /// <summary>
    /// 分頁查詢 ShoppingOrder
    /// </summary>

    public class QueryShoppingOrderRequest
        : PageableQuery, IRequest<Page<ShoppingOrderView>>
    {

        ///  <summary>
        ///訂單主檔Id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }
        ///  <summary>
        ///訂單總金額
        /// </summary>
        public int TotalAmount { get; set; }
        ///  <summary>
        ///付款總金額
        /// </summary>
        public int PaymentAmount { get; set; }
        ///  <summary>
        ///退款總金額
        /// </summary>
        public int RefundAmount { get; set; }
        ///  <summary>
        ///出席狀態 對應SystemConfig內Type=OrderStatus 0:尚未付款 1已付款 2:款項確認 3:異常
        /// </summary>
        public string OrderPayStatus { get; set; }
        ///  <summary>
        ///付款交易序號
        /// </summary>
        public string PaymentTransactionNo { get; set; }
        ///  <summary>
        ///付款交易時間
        /// </summary>
        public DateTime? PaymentTransactionDate { get; set; }
        ///  <summary>
        ///付款備註
        /// </summary>
        public string PaymentTransactionDescription { get; set; }
        ///  <summary>
        ///付款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷卡 3:其他
        /// </summary>
        public string PaymentType { get; set; }
        ///  <summary>
        ///退款交易序號
        /// </summary>
        public string RefundTransactionNo { get; set; }
        ///  <summary>
        ///退款交易時間
        /// </summary>
        public DateTime? RefundTransactionDate { get; set; }
        ///  <summary>
        ///退款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷退 3:其他
        /// </summary>
        public string RefundType { get; set; }
        ///  <summary>
        ///退款備註
        /// </summary>
        public string RefundDescription { get; set; }
        ///  <summary>
        ///出席狀態 對應SystemConfig內Type=OrderStatus 0:訂單成立(待付款)1:訂單對帳2:訂單已確認3:訂單已結案4:訂單取消申請5:訂單取消審核中6:訂單取消已確認7:訂單取消已駁回8:訂單取消退款中9:訂單取消已退款
        /// </summary>

        public string OrderStatus { get; set; }

        ///  <summary>
        ///電子收據
        /// </summary>
        public string Receipt { get; set; }
        ///  <summary>
        ///實收金額
        /// </summary>
        public int ActuallyAmount { get; set; }
        ///  <summary>
        ///收款人員 對應user.Id
        /// </summary>
        public long ReceiveUserId { get; set; }

        public long? OrganizationId { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }


    }

    /// <summary>
    ///  分頁查詢 ShoppingOrder
    /// </summary>
    public class QueryShoppingOrderRequestHandler
        : IRequestHandler<QueryShoppingOrderRequest, Page<ShoppingOrderView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryShoppingOrderRequestHandler(
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
        public async Task<Page<ShoppingOrderView>> Handle(
            QueryShoppingOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            var ids = new List<long>();
            if (request.OrganizationId.HasValue)
            {
                ids = await (from sod in this.appDbContext.ShoppingOrderDetails
                             from c in this.appDbContext.Courses
                             from cm in this.appDbContext.CourseManagements
                             where cm.OrganizationId == request.OrganizationId.Value &&
                                   c.CourseManagementId == cm.Id &&
                                   sod.CourseId == cm.Id
                             select sod.ShoppingOrderId).ToListAsync(cancellationToken);
            }

            var usrIds = new List<long>();
            if (!string.IsNullOrEmpty(request.UserName) ||
                !string.IsNullOrEmpty(request.Phone) ||
                !string.IsNullOrEmpty(request.EMail))
            {
                usrIds = await this.appDbContext.Users
                                      .WhereWhenNotEmpty(request.UserName, c => c.Name == request.UserName)
                                      .WhereWhenNotEmpty(request.Phone, c => c.Phone == request.Phone ||
                                                                             c.CellPhone1 == request.Phone ||
                                                                             c.CellPhone2 == request.Phone)
                                      .WhereWhenNotEmpty(request.EMail, c => c.Email1 == request.EMail ||
                                                                             c.Email2 == request.EMail)
                                      .Select(c => c.Id)
                                      .ToListAsync(cancellationToken);
            }

            /* TODO

    if (Request.OrganizationId != '') //要過濾有該堂點的訂單資料
                {
                    可有的資料：
    ShoppingCartOrder = select * from ShoppingOrder where Id in (select ShoppingOrderId from ShoppingOrderDetail where CourseId in (select Id from Course where CourseManagementId in (select id from CourseManagement where OrganizationId = '"+Request.OrganizationId+"')) );
                }

                if (Request.UserName != '') //要過濾姓名
                {
                    可有的資料：
    ShoppingCartOrder =
    select * from ShoppingOrder where UserId in (select Id from User where  Name = '"+Request.UserName+"' );
                }
                if (Request.Phone != '') //要過濾電話
                {
                    可有的資料：
    ShoppingCartOrder =
    select * from ShoppingOrder where UserId in (select Id from User where 1 = 1 and((Phone = '"+Request.Phone+"') or(CellPhone1 = '"+Request.Phone+"')or(CellPhone2 = '"+Request.Phone+"'))
                 );
                }
                if (Request.EMail != '') //要過濾EMail
                {
                    可有的資料：
    ShoppingCartOrder =
    select * from ShoppingOrder where UserId in (select Id from User where 1 = 1 and((Email1 = '"+Request.EMail+"') or(Email2 = '"+Request.EMail+"'))
                 );
                }
            */


            var main = await this.appDbContext
                            .ShoppingOrders
                            .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//訂單主檔Id
                .WhereWhen(ids.Count > 0, c => ids.Contains(c.Id))   //過濾有該堂點的訂單資料
                .WhereWhen(usrIds.Count > 0, c => usrIds.Contains(c.Id))   //要過濾姓名 電話 EMail
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                .WhereWhen(request.TotalAmount != 0, c => c.TotalAmount == request.TotalAmount)//訂單總金額
                .WhereWhen(request.PaymentAmount != 0, c => c.PaymentAmount == request.PaymentAmount)//付款總金額
                .WhereWhen(request.RefundAmount != 0, c => c.RefundAmount == request.RefundAmount)//退款總金額
                .WhereWhenNotEmpty(request.OrderPayStatus, c => c.OrderPayStatus == request.OrderPayStatus)//出席狀態 對應SystemConfig內Type=OrderStatus 0:尚未付款 1：已付款 2:款項確認 3:異常 4：訂單逾期取消付款
                .WhereWhenNotEmpty(request.PaymentTransactionNo, c => c.PaymentTransactionNo == request.PaymentTransactionNo)//付款交易序號
                .WhereWhen(request.PaymentTransactionDate != null, c => c.PaymentTransactionDate == request.PaymentTransactionDate)//付款交易時間
                .WhereWhenNotEmpty(request.PaymentTransactionDescription, c => c.PaymentTransactionDescription == request.PaymentTransactionDescription)//付款備註
                .WhereWhenNotEmpty(request.PaymentType, c => c.PaymentType == request.PaymentType)//付款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷卡 3:其他
                .WhereWhenNotEmpty(request.RefundTransactionNo, c => c.RefundTransactionNo == request.RefundTransactionNo)//退款交易序號
                .WhereWhen(request.RefundTransactionDate != null, c => c.RefundTransactionDate == request.RefundTransactionDate)//退款交易時間
                .WhereWhenNotEmpty(request.RefundType, c => c.RefundType == request.RefundType)//退款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷退 3:其他

                .WhereWhenNotEmpty(request.RefundDescription, c => c.RefundDescription == request.RefundDescription)//退款備註
                .WhereWhenNotEmpty(request.OrderStatus, c => c.OrderStatus == request.OrderStatus)//訂單狀態 對應SystemConfig內Type=OrderStatus 0:訂單成立(待付款)1:訂單對帳2: 訂單已確認3: 訂單已結案4: 訂單取消申請5: 訂單取消審核中6: 訂單取消已確認7: 訂單取消已駁回8: 訂單取消退款中9: 訂單取消已退款"
                .WhereWhenNotEmpty(request.Receipt, c => c.Receipt == request.Receipt)//電子收據
                .WhereWhen(request.ActuallyAmount != 0, c => c.ActuallyAmount == request.ActuallyAmount)//實收金額

                .WhereWhen(Convert.ToInt64(request.ReceiveUserId) != 0, c => c.ReceiveUserId == request.ReceiveUserId)//收款人員 對應user.Id
                .ProjectTo<ShoppingOrderView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
            if (main.Records.Count() > 0)
            {
                //從ShoppingOrder找出ShoppingOrderDetail資料
                var sodLst = await this.appDbContext.ShoppingOrderDetails
                           .Where(c => main.Records.Select(c => c.Id).Contains(c.ShoppingOrderId))
                           .ProjectTo<ShoppingOrderDetailView>(this.mapper.ConfigurationProvider)
                           .ToListAsync(cancellationToken);

                // 從ShoppingOrderDetail 找出Course資料
                var courseLst = await this.appDbContext.Courses
                                .Where(c => sodLst.Select(c => c.CourseId).Contains(c.Id))
                                .ProjectTo<CourseView>(this.mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);

                foreach (var record in main.Records)
                {
                    record.ShoppingOrderDetailViews = sodLst.Where(c => c.ShoppingOrderId == record.Id).ToList();
                    foreach (var detail in record.ShoppingOrderDetailViews)
                    {
                        detail.CourseViews = courseLst.Where(c => c.Id == detail.CourseId).ToList();
                    }
                }
            }

            return main;

            ////從ShoppingOrder找出ShoppingOrderDetail資料
            //var sodLst = this.appDbContext.ShoppingOrderDetails
            //                 .Where(c => main.Select(c => c.Id).Contains(c.ShoppingOrderId));

            //// 從ShoppingOrderDetail 找出Course資料
            //var courseLst = this.appDbContext.Courses
            //                .Where(c => sodLst.Select(c => c.CourseId).Contains(c.Id));

            //var result = from m in main
            //             join sod in sodLst on m.Id equals sod.CourseId into lst1
            //             from sod in lst1.DefaultIfEmpty()
            //             join cts in courseLst on sod.CourseId equals cts.Id into lst2
            //             from cts in lst2.DefaultIfEmpty()
            //             select new ShoppingOrderView
            //             {
            //                 Id = m.Id,
            //                 DateCreate = m.DateCreate,
            //                 UserId = m.UserId,
            //                 TotalAmount = m.TotalAmount,
            //                 PaymentAmount = m.PaymentAmount,
            //                 RefundAmount = m.RefundAmount,
            //                 OrderPayStatus = m.OrderPayStatus,
            //                 PaymentTransactionNo = m.PaymentTransactionNo,
            //                 PaymentTransactionDate = m.PaymentTransactionDate,
            //                 PaymentTransactionDescription = m.PaymentTransactionDescription,
            //                 PaymentType = m.PaymentType,
            //                 RefundTransactionNo = m.RefundTransactionNo,
            //                 RefundTransactionDate = m.RefundTransactionDate,
            //                 RefundType = m.RefundType,
            //                 RefundDescription = m.RefundDescription,
            //                 OrderStatus = m.OrderStatus,
            //                 Receipt = m.Receipt,
            //                 ActuallyAmount = m.ActuallyAmount,
            //                 ReceiveUserId = m.ReceiveUserId,
            //             };
            //foreach (var obj in result)
            //{
            //    obj.ShoppingOrderDetails = sodLst.Where(c => c.ShoppingOrderId == obj.Id).ToList();
            //    foreach (var obj2 in obj.ShoppingOrderDetails)
            //    {
            //        //obj2.Courses = courseLst.Where(c => c.Id == obj2.ShoppingOrderId);
            //    }
            //}
            //return result;


            //return await this.appDbContext
            //   .ShoppingOrders
            //    .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//訂單主檔Id
            //    .WhereWhen(ids.Count > 0, c => ids.Contains(c.Id))   //過濾有該堂點的訂單資料
            //    .WhereWhen(usrIds.Count > 0, c => usrIds.Contains(c.Id))   //要過濾姓名 電話 EMail
            //    .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
            //    .WhereWhen(request.TotalAmount != 0, c => c.TotalAmount == request.TotalAmount)//訂單總金額
            //    .WhereWhen(request.PaymentAmount != 0, c => c.PaymentAmount == request.PaymentAmount)//付款總金額
            //    .WhereWhen(request.RefundAmount != 0, c => c.RefundAmount == request.RefundAmount)//退款總金額
            //    .WhereWhenNotEmpty(request.OrderPayStatus, c => c.OrderPayStatus == request.OrderPayStatus)//出席狀態 對應SystemConfig內Type=OrderStatus 0:尚未付款 1：已付款 2:款項確認 3:異常 4：訂單逾期取消付款
            //    .WhereWhenNotEmpty(request.PaymentTransactionNo, c => c.PaymentTransactionNo == request.PaymentTransactionNo)//付款交易序號
            //    .WhereWhen(request.PaymentTransactionDate != null, c => c.PaymentTransactionDate == request.PaymentTransactionDate)//付款交易時間
            //    .WhereWhenNotEmpty(request.PaymentTransactionDescription, c => c.PaymentTransactionDescription == request.PaymentTransactionDescription)//付款備註
            //    .WhereWhenNotEmpty(request.PaymentType, c => c.PaymentType == request.PaymentType)//付款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷卡 3:其他
            //    .WhereWhenNotEmpty(request.RefundTransactionNo, c => c.RefundTransactionNo == request.RefundTransactionNo)//退款交易序號
            //    .WhereWhen(request.RefundTransactionDate != null, c => c.RefundTransactionDate == request.RefundTransactionDate)//退款交易時間
            //    .WhereWhenNotEmpty(request.RefundType, c => c.RefundType == request.RefundType)//退款方式 對應SystemConfig內Type=PaymentType 0:臨櫃現金 1:ATM 2:刷退 3:其他
            //    .WhereWhenNotEmpty(request.RefundDescription, c => c.RefundDescription == request.RefundDescription)//退款備註
            //    .WhereWhenNotEmpty(request.OrderStatus, c => c.OrderStatus == request.OrderStatus)//訂單狀態 對應SystemConfig內Type=OrderStatus 0:訂單成立(待付款)1:訂單對帳2: 訂單已確認3: 訂單已結案4: 訂單取消申請5: 訂單取消審核中6: 訂單取消已確認7: 訂單取消已駁回8: 訂單取消退款中9: 訂單取消已退款"
            //    .WhereWhenNotEmpty(request.Receipt, c => c.Receipt == request.Receipt)//電子收據
            //    .WhereWhen(request.ActuallyAmount != 0, c => c.ActuallyAmount == request.ActuallyAmount)//實收金額
            //    .WhereWhen(Convert.ToInt64(request.ReceiveUserId) != 0, c => c.ReceiveUserId == request.ReceiveUserId)//收款人員 對應user.Id
            //   .ProjectTo<ShoppingOrderView>(this.mapper.ConfigurationProvider)
            //   .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
            //   .ToPageAsync(request);


        }
    }
}
