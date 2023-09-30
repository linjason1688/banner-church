#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.CreateMinistrySchedule
{
    /// <summary>
    /// 建立 MinistrySchedule
    /// </summary>

    public class CreateMinistryScheduleCommand :  MinistryScheduleBase, IRequest<MinistryScheduleView>
    {
        public List<CreateMinistryScheduleDetailCommand> MinistryScheduleDetails { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryScheduleCommandHandler : IRequestHandler<CreateMinistryScheduleCommand, MinistryScheduleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryScheduleCommandHandler(
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
        public async Task<MinistryScheduleView> Handle(
            CreateMinistryScheduleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistrySchedule>(command);

            await this.appDbContext.MinistrySchedules.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryScheduleView>(entity);
        }
    }
}
