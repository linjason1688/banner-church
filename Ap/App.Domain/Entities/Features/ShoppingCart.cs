using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class ShoppingCart : EntityBase
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
        ///  <summary>
        ///是否超過優惠日期後關閉對應type=IsYN顯示 namevalue存此欄0N1Yif1ThendataTimeCourse.DiscountSignUpDate關閉此選項
        /// </summary>
      

        public string StatusCd { get; set; }

    }
}
