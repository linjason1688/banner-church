#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix
{
    /// <summary>
    /// 建立 CourseAppendix
    /// </summary>

    public class CreateCourseAppendixCommand :  CourseAppendixBase, IRequest<CourseAppendixView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseAppendixCommandHandler : IRequestHandler<CreateCourseAppendixCommand, CourseAppendixView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseAppendixCommandHandler(
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
        public async Task<CourseAppendixView> Handle(
            CreateCourseAppendixCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseAppendix>(command);

            await this.appDbContext.CourseAppendixs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseAppendixView>(entity);
        }
    }
}
