using System;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using System.Collections.Generic;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilters.Dtos
{
    /// <summary>
    /// CourseManagementFilter 
    /// </summary>
    public class CourseManagementFilterView : CourseManagementFilterBase, IEntityBase
    {


        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }


        ///// <summary>
        /////  Id
        ///// </summary>
        //public long Id { get; set; }

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
        /// 課程過濾主檔_課程必修
        /// </summary>
        public List<CourseManagementFilterCourseView> CourseManagementFilterCourses { get; set; } = new();

        /// <summary>
        /// 課程樣版過濾牧場主檔
        /// </summary>
        public List<CourseManagementFilterPastoralView> CourseManagementFilterPastorals { get; set; } = new();

        /// <summary>
        /// 課程樣版過濾職份主檔
        /// </summary>
        public List<CourseManagementFilterRespView> CourseManagementFilterResps { get; set; } = new();

        /// <summary>
        /// 課程樣版過濾會員
        /// </summary>
        public List<CourseManagementFilterUserView> CourseManagementFilterUsers { get; set; } = new();


    }
}
