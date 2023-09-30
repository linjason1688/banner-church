#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Commands.CreateCourseTimeSchedule
{
    /// <summary>
    /// 建立 CourseTimeSchedule
    /// </summary>

    public class CreateCourseTimeScheduleCommand :  CourseTimeScheduleBase, IRequest<CourseTimeScheduleView>
    {
        /// <summary>
        /// 課程時段講師檔
        /// </summary>
        public  List<CreateCourseTimeScheduleTeacherCommand> CourseTimeScheduleTeachers { get; set; }

        public CreateCourseTimeScheduleCommand()
        {
            this.CourseTimeScheduleTeachers = new List<CreateCourseTimeScheduleTeacherCommand>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleCommandHandler : IRequestHandler<CreateCourseTimeScheduleCommand, CourseTimeScheduleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleCommandHandler(
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
        public async Task<CourseTimeScheduleView> Handle(
            CreateCourseTimeScheduleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseTimeSchedule>(command);

            await this.appDbContext.CourseTimeSchedules.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseTimeScheduleView>(entity);
        }
    }
}
