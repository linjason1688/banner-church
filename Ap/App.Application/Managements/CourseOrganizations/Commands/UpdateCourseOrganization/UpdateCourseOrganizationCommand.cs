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
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseOrganizations.Commands.UpdateCourseOrganization
{
    /// <summary>
    /// 更新  CourseOrganization
    /// </summary>

    public class UpdateCourseOrganizationCommand : CourseOrganizationBase,IRequest<CourseOrganizationView>
    {
    
       
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseOrganizationCommandHandler : IRequestHandler<UpdateCourseOrganizationCommand, CourseOrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseOrganizationCommandHandler(
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
            UpdateCourseOrganizationCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.CourseOrganizations.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseOrganizationView>(entity);
        }
    }
}
