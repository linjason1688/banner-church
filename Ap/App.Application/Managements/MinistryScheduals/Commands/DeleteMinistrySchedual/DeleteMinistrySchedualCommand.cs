#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using App.Application.Managements.MinistryScheduleDetails.Commands.DeleteMinistryScheduleDetail;

#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule
{
    /// <summary>
    /// 刪除  MinistrySchedule
    /// </summary>

    public class DeleteMinistryScheduleCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
        public List<DeleteMinistryScheduleDetailCommand> MinistryScheduleDetails { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryScheduleCommandHandler : IRequestHandler<DeleteMinistryScheduleCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryScheduleCommandHandler(
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
        public async Task<Unit> Handle(
            DeleteMinistryScheduleCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.MinistrySchedules.RemoveAsync(
                new MinistrySchedule()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
