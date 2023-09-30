#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Commands.UpdateCourseManagementFilterCourse
{
    /// <summary>
    /// 更新  CourseManagementFilterCourse
    /// </summary>

    public class UpdateCourseManagementFilterCourseCommand : CourseManagementFilterCourseBase,IRequest<CourseManagementFilterCourseView>
    {
    
        //public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterCourseCommandHandler : IRequestHandler<UpdateCourseManagementFilterCourseCommand, CourseManagementFilterCourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterCourseCommandHandler(
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
        public async Task<CourseManagementFilterCourseView> Handle(
            UpdateCourseManagementFilterCourseCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.CourseManagementFilterCourses.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementFilterCourseView>(entity);
        }
    }
}
