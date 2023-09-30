#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseOrganizations.Commands.CreateCourseOrganization
{
    /// <summary>
    /// 建立 CourseOrganization
    /// </summary>

    public class CreateCourseOrganizationCommand :  CourseOrganizationBase, IRequest<CourseOrganizationView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseOrganizationCommandHandler : IRequestHandler<CreateCourseOrganizationCommand, CourseOrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseOrganizationCommandHandler(
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
        public async Task<CourseOrganizationView> Handle(
            CreateCourseOrganizationCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseOrganization>(command);

            await this.appDbContext.CourseOrganizations.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseOrganizationView>(entity);
        }
    }
}
