#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher
{
    /// <summary>
    /// 建立 CourseTimeScheduleTeacher
    /// </summary>

    public class CreateCourseTimeScheduleTeacherCommand :  CourseTimeScheduleTeacherBase, IRequest<CourseTimeScheduleTeacherView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleTeacherCommandHandler : IRequestHandler<CreateCourseTimeScheduleTeacherCommand, CourseTimeScheduleTeacherView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleTeacherCommandHandler(
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
        public async Task<CourseTimeScheduleTeacherView> Handle(
            CreateCourseTimeScheduleTeacherCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseTimeScheduleTeacher>(command);

            await this.appDbContext.CourseTimeScheduleTeachers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseTimeScheduleTeacherView>(entity);
        }
    }
}
