using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseManagement : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagementType.Id
        /// </summary>
        public long CourseManagementTypeId { get; set; }

        ///  <summary>
        ///堂點Id Organization.Id
        /// </summary>
        public long OrganizationId { get; set; }

        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }

        ///  <summary>
        ///課程作業繳交日期
        /// </summary>
        public DateTime HomeworkDate { get; set; }

        ///  <summary>
        ///課程標題
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string Description { get; set; }

        ///  <summary>
        ///對象資格說明
        /// </summary>
        public string BasicQualification { get; set; }


        ///  <summary>
        ///結業資格說明
        /// </summary>
        public string GraduationQualification { get; set; }


        ///  <summary>
        ///課程類別 0實體 1線上 2網路學校
        /// </summary>
        public string CourseType { get; set; }


        ///  <summary>
        ///課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
        /// </summary>
        public string CourseManagementStatus { get; set; }

        public string StatusCd { get; set; }

    }
}
