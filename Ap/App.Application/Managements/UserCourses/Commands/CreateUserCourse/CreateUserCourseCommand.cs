#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserCourses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserCourses.Commands.CreateUserCourse
{
    /// <summary>
    /// 建立 UserCourse
    /// </summary>

    public class CreateUserCourseCommand :  UserCourseBase, IRequest<UserCourseView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserCourseCommandHandler : IRequestHandler<CreateUserCourseCommand, UserCourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserCourseCommandHandler(
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
        public async Task<UserCourseView> Handle(
            CreateUserCourseCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserCourse>(command);

            await this.appDbContext.UserCourses.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserCourseView>(entity);
        }
    }
}
