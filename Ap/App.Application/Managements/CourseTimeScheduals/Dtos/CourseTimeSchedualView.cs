using System;
using System.Collections.Generic;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseTimeSchedules.Dtos
{
    /// <summary>
    /// CourseTimeSchedule 
    /// </summary>
    public class CourseTimeScheduleView : CourseTimeScheduleBase, IEntityBase
    {


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

        public List<CourseTimeScheduleTeacherView> CourseTimeScheduleTeachers { get; set; }

        public CourseTimeScheduleView()
        {
            this.CourseTimeScheduleTeachers = new List<CourseTimeScheduleTeacherView>();
        }

    }
}
