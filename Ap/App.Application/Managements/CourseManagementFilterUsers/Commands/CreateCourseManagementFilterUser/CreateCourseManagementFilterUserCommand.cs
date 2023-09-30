#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser
{
    /// <summary>
    /// 建立 CourseManagementFilterUser
    /// </summary>

    public class CreateCourseManagementFilterUserCommand :  CourseManagementFilterUserBase, IRequest<CourseManagementFilterUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterUserCommandHandler : IRequestHandler<CreateCourseManagementFilterUserCommand, CourseManagementFilterUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterUserCommandHandler(
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
        public async Task<CourseManagementFilterUserView> Handle(
            CreateCourseManagementFilterUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementFilterUser>(command);

            await this.appDbContext.CourseManagementFilterUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementFilterUserView>(entity);
        }
    }
}
