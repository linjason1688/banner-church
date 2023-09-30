using System;
using System.Collections.Generic;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagements.Dtos;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Courses.Dtos
{
    /// <summary>
    /// Course 
    /// </summary>
    public class CourseView : CourseBase, IEntityBase
    {




        ///  <summary>
        ///課程類別名稱
        /// </summary>
        public string CourseManagementTitle { get; set; }

        ///  <summary>
        ///已報名人數
        /// </summary>
        public int SignUpCount { get; set; }

        ///  <summary>
        ///已繳費人數
        /// </summary>
        public int PaymentCount { get; set; }

        ///  <summary>
        ///班級人數
        /// </summary>
        public int StudentCount { get; set; }

        ///  <summary>
        ///開課班級與時段
        /// </summary>
        public string CourseInformations { get; set; }


        ///  <summary>
        ///永久課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }

        ///  <summary>
        ///課程說明
        /// </summary>
        public string CourseManagementDescription { get; set; }


        ///  <summary>
        ///課程類別名稱
        /// </summary>
        public string CourseManagementTypeName { get; set; }

    

        /// <summary>
        /// CourseIsFilter：是否有擋修 0否 1是
        /// </summary>
        /// <remarks>
        ///  CourseIsFilter：是否有擋修 0否 1是
        /// </remarks>
        public string CourseIsFilter { get; set; }


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public List<CoursePriceView> CoursePrices { get; set; }

        /// <summary>
        /// 堂點
        /// </summary>
        public List<CourseOrganizationView> CourseOrganizations { get; set; }

        /// <summary>
        /// 課程時間
        /// </summary>
        public List<CourseTimeScheduleView> CourseTimeSchedules { get; set; }

        /// <summary>
        /// 課程主檔 
        /// </summary>
        public CourseManagementView CourseManagement { get; set; }

        /// <summary>
        /// 課程過濾主檔
        /// </summary>
        public CourseManagementFilterView CourseManagementFilter { get; set; } = new();
        
        public CourseView()
        {
            this.CourseOrganizations = new List<CourseOrganizationView>();
            this.CoursePrices = new List<CoursePriceView>();
            this.CourseTimeSchedules = new List<CourseTimeScheduleView>();
        }
    }
}
