using System;
using System.Collections.Generic;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;

namespace App.Application.Managements.CourseManagements.Dtos
{
    /// <summary>
    /// 課程樣版主檔
    /// </summary>
    public class CourseManagementBase
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
        ///課程標題
        /// </summary>
        public string Title { get; set; }

        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string Description { get; set; }

        ///  <summary>
        ///課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
        /// </summary>
        public string CourseManagementStatus { get; set; }


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

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
        
        /// <summary>
        /// 課程過濾主檔
        /// </summary>
        public List<CourseManagementFilterBase> CourseManagementFilters { get; set; }

        /// <summary>
        /// 課程過濾主檔_課程必修
        /// </summary>
        public List<CourseManagementFilterCourseBase> CourseManagementFilterCourses { get; set; }

        /// <summary>
        /// 課程樣版過濾牧場主檔
        /// </summary>
        public List<CourseManagementFilterPastoralBase> CourseManagementFilterPastorals { get; set; }

        /// <summary>
        /// 課程樣版過濾職份主檔
        /// </summary>
        public List<CourseManagementFilterRespBase> CourseManagementFilterResps { get; set; }


        /// <summary>
        /// 課程樣版過濾會員
        /// </summary>
        public List<CourseManagementFilterUserBase> CourseManagementFilterUsers { get; set; }
    }
}
