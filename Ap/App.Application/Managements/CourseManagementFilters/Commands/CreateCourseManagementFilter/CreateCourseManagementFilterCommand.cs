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
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter
{
    /// <summary>
    /// 建立 CourseManagementFilter
    /// </summary>

    public class CreateCourseManagementFilterCommand :  CourseManagementFilterBase, IRequest<CourseManagementFilterView>
    {
        /// <summary>
        /// 課程過濾主檔_課程必修
        /// </summary>
        public List<CreateCourseManagementFilterCourseCommand> CourseManagementFilterCourses { get; set; }

        /// <summary>
        /// 課程樣版過濾牧場主檔
        /// </summary>
        public List<CreateCourseManagementFilterPastoralCommand> CourseManagementFilterPastorals { get; set; }

        /// <summary>
        /// 課程樣版過濾職份主檔
        /// </summary>
        public List<CreateCourseManagementFilterRespCommand> CourseManagementFilterResps { get; set; }

        /// <summary>
        /// 課程樣版過濾會員
        /// </summary>
        public List<CreateCourseManagementFilterUserCommand> CourseManagementFilterUsers { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterCommandHandler : IRequestHandler<CreateCourseManagementFilterCommand, CourseManagementFilterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterCommandHandler(
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
        public async Task<CourseManagementFilterView> Handle(
            CreateCourseManagementFilterCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementFilter>(command);

            await this.appDbContext.CourseManagementFilters.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementFilterView>(entity);
        }
    }
}
