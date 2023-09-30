#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.CourseManagementAppendixs.Commands.CreateCourseManagementAppendix
{
    /// <summary>
    /// 建立 CourseManagementAppendix
    /// </summary>

    public class CreateCourseManagementAppendixCommand :  CourseManagementAppendixBase, IRequest<CourseManagementAppendixView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementAppendixCommandHandler : IRequestHandler<CreateCourseManagementAppendixCommand, CourseManagementAppendixView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementAppendixCommandHandler(
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
            CreateCourseManagementAppendixCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementAppendix>(command);

            await this.appDbContext.CourseManagementAppendixs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementAppendixView>(entity);
        }
    }
}
