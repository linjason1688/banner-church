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
using App.Application.Managements.CourseManagementAppendixs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Commands.UpdateCourseManagementAppendix
{
    /// <summary>
    /// 更新  CourseManagementAppendix
    /// </summary>

    public class UpdateCourseManagementAppendixCommand : CourseManagementAppendixBase,IRequest<CourseManagementAppendixView>
    {
    
        //public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementAppendixCommandHandler : IRequestHandler<UpdateCourseManagementAppendixCommand, CourseManagementAppendixView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementAppendixCommandHandler(
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
        public async Task<CourseManagementAppendixView> Handle(
            UpdateCourseManagementAppendixCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.CourseManagementAppendixs.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementAppendixView>(entity);
        }
    }
}
