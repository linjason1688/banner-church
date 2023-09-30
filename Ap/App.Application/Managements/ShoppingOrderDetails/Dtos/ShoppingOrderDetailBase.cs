


using System;

namespace App.Application.Managements.ShoppingOrderDetails.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoppingOrderDetailBase
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
        ///是否素食 SystemConfig內Type=IsYN 0:否 1:是
        /// </summary>
        public string IsViggieHelp { get; set; }

        ///  <summary>
        ///是否行動不便 SystemConfig內Type=IsYN 0:否 1:是
        /// </summary>
        public string IsMoveHelp { get; set; }

        ///  <summary>
        ///是否懷孕 SystemConfig內Type=IsYN 0:否 1:是
        /// </summary>
        public string IsPregnancyHelp { get; set; }

        ///  <summary>
        ///是否其他需要幫助 SystemConfig內Type=IsYN 0:否 1:是
        /// </summary>
        public string IsOthersHelp { get; set; }

        ///  <summary>
        ///其他需要幫助說明
        /// </summary>
        public string IsOthersHelpInformations { get; set; }

        ///  <summary>
        ///是否同班夫妻幫助 SystemConfig內Type=IsYN 0:否 1:是
        /// </summary>
        public string IsCoupleSameClassHelp { get; set; }

        ///  <summary>
        ///同班夫妻配偶姓名
        /// </summary>
        public string IsCoupleSameClassInformations { get; set; }

    }
}

