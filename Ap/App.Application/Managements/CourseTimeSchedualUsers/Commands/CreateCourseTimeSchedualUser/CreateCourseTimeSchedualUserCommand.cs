#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseTimeScheduleUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Commands.CreateCourseTimeScheduleUser
{
    /// <summary>
    /// 建立 CourseTimeScheduleUser
    /// </summary>

    public class CreateCourseTimeScheduleUserCommand :  CourseTimeScheduleUserBase, IRequest<CourseTimeScheduleUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleUserCommandHandler : IRequestHandler<CreateCourseTimeScheduleUserCommand, CourseTimeScheduleUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleUserCommandHandler(
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
        public async Task<CourseTimeScheduleUserView> Handle(
            CreateCourseTimeScheduleUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseTimeScheduleUser>(command);

            await this.appDbContext.CourseTimeScheduleUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseTimeScheduleUserView>(entity);
        }
    }
}
