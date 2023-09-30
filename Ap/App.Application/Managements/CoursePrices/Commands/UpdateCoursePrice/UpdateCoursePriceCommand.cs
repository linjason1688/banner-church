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
using App.Application.Managements.CoursePrices.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.CoursePrices.Commands.UpdateCoursePrice
{
    /// <summary>
    /// 更新  CoursePrice
    /// </summary>

    public class UpdateCoursePriceCommand : CoursePriceBase,IRequest<CoursePriceView>
    {
    
       
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateCoursePriceCommandHandler : IRequestHandler<UpdateCoursePriceCommand, CoursePriceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateCoursePriceCommandHandler(
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
        public async Task<CoursePriceView> Handle(
            UpdateCoursePriceCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.CoursePrices.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<CoursePriceView>(entity);
        }
    }
}
