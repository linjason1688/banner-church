using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CoursePrice : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///價格名稱
        /// </summary>
        public string PriceName { get; set; }
        ///  <summary>
        ///價格
        /// </summary>
        public int Price { get; set; }
        ///  <summary>
        ///是否公開對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsPublic { get; set; }
        ///  <summary>
        ///是否超過優惠日期後關閉對應type=IsYN顯示 namevalue存此欄0N1Yif1ThendataTimeCourse.DiscountSignUpDate關閉此選項
        /// </summary>
        public string IsDueDate { get; set; }


        public string StatusCd { get; set; }

    }
}
