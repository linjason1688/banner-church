#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementFilterCourses.Commands.CreateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser;
using App.Application.Managements.CourseOrganizations.Commands.CreateCourseOrganization;
using App.Application.Managements.CoursePrices.Commands.CreateCoursePrice;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.CourseTimeSchedules.Commands.CreateCourseTimeSchedule;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher;
using App.Application.Managements.Teachers.Commands.CreateTeacher;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Courses.Commands.CreateCourse
{
    /// <summary>
    /// 建立 Course
    /// </summary>
    public class CreateCourseCommand : CourseBase, IRequest<CourseView>
    {
        /// <summary>
        /// 課程堂點主檔
        /// </summary>
        public List<CreateCourseOrganizationCommand> CourseOrganizations { get; set; }


        /// <summary>
        /// 課程價格主檔
        /// </summary>
        public List<CreateCoursePriceCommand> CoursePrices { get; set; }


    

        /// <summary>
        /// 課程過濾主檔
        /// </summary>
        public CreateCourseManagementFilterCommand CourseManagementFilter { get; set; } = new ();

        /// <summary>
        /// 課程時段檔
        /// </summary>
        public List<CreateCourseTimeScheduleCommand> CourseTimeSchedules { get; set; }


        /// <summary>
        /// 課程過濾樣板事工團
        /// </summary>
        public List<CreateCourseManagementFilterRespCommand> CourseManagementFilterResps { get; set; }



        /// <summary>
        /// 課程過濾樣板特殊會員
        /// </summary>
        public List<CreateCourseManagementFilterUserCommand> CourseManagementFilterUsers { get; set; }

        /// <summary>
        /// 課程過濾樣板牧場
        /// </summary>
        public List<CreateCourseManagementFilterPastoralCommand> CourseManagementFilterPastorals { get; set; }

        /// <summary>
        /// 課程過濾樣板課程
        /// </summary>
        public List<CreateCourseManagementFilterCourseCommand> CourseManagementFilterCourses { get; set; }






        public CreateCourseCommand()
        {
            this.CourseOrganizations = new List<CreateCourseOrganizationCommand>();
            this.CoursePrices = new List<CreateCoursePriceCommand>();
            this.CourseTimeSchedules = new List<CreateCourseTimeScheduleCommand>();

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseCommandHandler(
            IMapper mapper,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CourseView> Handle(
            CreateCourseCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Course>(command);

            await this.appDbContext.Courses.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseView>(entity);
        }
    }
}
