using System;
using App.Application.Managements.CourseManagementFilterCourses.Commands.CreateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser;
using System.Collections.Generic;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagements.Dtos
{
    /// <summary>
    /// CourseManagement 
    /// </summary>
    public class CourseManagementView : CourseManagementBase, IEntityBase
    {

        ///// <summary>
        ///// 課程過濾主檔
        ///// </summary>
        //public List<CourseManagementFilterView> CourseManagementFilters { get; set; }

        ///// <summary>
        ///// 課程過濾主檔_課程必修
        ///// </summary>
        //public List<CourseManagementFilterCourseView> CourseManagementFilterCourses { get; set; }

        ///// <summary>
        ///// 課程樣版過濾牧場主檔
        ///// </summary>
        //public List<CourseManagementFilterPastoralView> CourseManagementFilterPastorals { get; set; }

        ///// <summary>
        ///// 課程樣版過濾職份主檔
        ///// </summary>
        //public List<CourseManagementFilterRespView> CourseManagementFilterResps { get; set; }


        ///// <summary>
        ///// 課程樣版過濾會員
        ///// </summary>
        //public List<CourseManagementFilterUserView> CourseManagementFilterUsers { get; set; }

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

        public CourseManagementType CourseManagement { get; set; }
    }
}
