#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseManagementTypes.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Commands.CreateCourseManagementType
{
    /// <summary>
    /// 建立 CourseManagementType
    /// </summary>

    public class CreateCourseManagementTypeCommand :  CourseManagementTypeBase, IRequest<CourseManagementTypeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementTypeCommandHandler : IRequestHandler<CreateCourseManagementTypeCommand, CourseManagementTypeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementTypeCommandHandler(
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
        public async Task<CourseManagementTypeView> Handle(
            CreateCourseManagementTypeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<CourseManagementType>(command);

            await this.appDbContext.CourseManagementTypes.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CourseManagementTypeView>(entity);
        }
    }
}
