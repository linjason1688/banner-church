#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp
{
    /// <summary>
    /// 建立 CourseManagementFilterResp
    /// </summary>

    public class CreateCourseManagementFilterRespCommand :  CourseManagementFilterRespBase, IRequest<CourseManagementFilterRespView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterRespCommandHandler : IRequestHandler<CreateCourseManagementFilterRespCommand, CourseManagementFilterRespView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterRespCommandHandler(
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
        public async Task<CourseManagementFilterRespView> Handle(
            CreateCourseManagementFilterRespCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementFilterResp>(command);

            await this.appDbContext.CourseManagementFilterResps.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementFilterRespView>(entity);
        }
    }
}
