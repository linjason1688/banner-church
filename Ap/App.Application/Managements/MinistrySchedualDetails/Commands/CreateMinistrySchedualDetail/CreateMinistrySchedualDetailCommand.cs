#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail
{
    /// <summary>
    /// 建立 MinistryScheduleDetail
    /// </summary>

    public class CreateMinistryScheduleDetailCommand :  MinistryScheduleDetailBase, IRequest<MinistryScheduleDetailView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryScheduleDetailCommandHandler : IRequestHandler<CreateMinistryScheduleDetailCommand, MinistryScheduleDetailView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryScheduleDetailCommandHandler(
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
        public async Task<MinistryScheduleDetailView> Handle(
            CreateMinistryScheduleDetailCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryScheduleDetail>(command);

            await this.appDbContext.MinistryScheduleDetails.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryScheduleDetailView>(entity);
        }
    }
}
