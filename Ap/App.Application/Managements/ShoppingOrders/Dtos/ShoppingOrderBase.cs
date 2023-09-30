


using System;

namespace App.Application.Managements.ShoppingOrders.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoppingOrderBase
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
        ///出席狀態 對應SystemConfig內Type=OrderStatus 0:尚未付款 1已付款 2:款項確認 3:異常 4：訂單逾期取消付款
        /// </summary>
        public string OrderPayStatus { get; set; }
        ///  <summary>
        ///付款交易序號
        /// </summary>
        public string PaymentTransactionNo { get; set; }
        ///  <summary>
        ///付款交易時間
        /// </summary>
        public DateTime PaymentTransactionDate { get; set; }
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
        public DateTime RefundTransactionDate { get; set; }
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




        ///  <summary>
        ///訂購人資料-姓名
        /// </summary>
        public string UserName { get; set; }

        ///  <summary>
        ///訂購人資料-通信地址
        /// </summary>
        public string UserAddress { get; set; }

        ///  <summary>
        ///訂購人資料-行動電話
        /// </summary>
        public string UserCellPhone { get; set; }

        ///  <summary>
        ///訂購人資料-聯絡電話
        /// </summary>
        public string UserPhone { get; set; }

        ///  <summary>
        ///訂購人資料-Email
        /// </summary>
        public string UserEmail { get; set; }

    }
}

