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
using App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Commands.UpdateMinistryScheduleDetail;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.UpdateMinistrySchedule
{
    /// <summary>
    /// 更新  MinistrySchedule
    /// </summary>

    public class UpdateMinistryScheduleCommand : MinistryScheduleBase,IRequest<MinistryScheduleView>
    {
    
        //public long Id { get; set; }
        public List<CreateMinistryScheduleDetailCommand> MinistryScheduleDetails { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryScheduleCommandHandler : IRequestHandler<UpdateMinistryScheduleCommand, MinistryScheduleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryScheduleCommandHandler(
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
            UpdateMinistryScheduleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.MinistrySchedules.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryScheduleView>(entity);
        }
    }
}
