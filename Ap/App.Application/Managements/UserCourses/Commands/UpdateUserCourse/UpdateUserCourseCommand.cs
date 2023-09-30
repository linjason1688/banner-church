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
using App.Application.Managements.UserCourses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserCourses.Commands.UpdateUserCourse
{
    /// <summary>
    /// 更新  UserCourse
    /// </summary>

    public class UpdateUserCourseCommand : UserCourseBase,IRequest<UserCourseView>
    {
    
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserCourseCommandHandler : IRequestHandler<UpdateUserCourseCommand, UserCourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateUserCourseCommandHandler(
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
            UpdateUserCourseCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.UserCourses.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserCourseView>(entity);
        }
    }
}
