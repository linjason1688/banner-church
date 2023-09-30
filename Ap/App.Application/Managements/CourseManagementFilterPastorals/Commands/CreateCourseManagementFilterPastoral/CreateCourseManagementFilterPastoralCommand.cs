#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral
{
    /// <summary>
    /// 建立 CourseManagementFilterPastoral
    /// </summary>

    public class CreateCourseManagementFilterPastoralCommand :  CourseManagementFilterPastoralBase, IRequest<CourseManagementFilterPastoralView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterPastoralCommandHandler : IRequestHandler<CreateCourseManagementFilterPastoralCommand, CourseManagementFilterPastoralView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterPastoralCommandHandler(
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
        public async Task<CourseManagementFilterPastoralView> Handle(
            CreateCourseManagementFilterPastoralCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementFilterPastoral>(command);

            await this.appDbContext.CourseManagementFilterPastorals.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementFilterPastoralView>(entity);
        }
    }
}
