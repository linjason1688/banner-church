#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MeetingPoints.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MeetingPoints.Commands.CreateMeetingPoint
{
    /// <summary>
    /// 建立 MeetingPoint
    /// </summary>

    public class CreateMeetingPointCommand :  MeetingPointBase, IRequest<MeetingPointView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMeetingPointCommandHandler : IRequestHandler<CreateMeetingPointCommand, MeetingPointView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMeetingPointCommandHandler(
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
        public async Task<MeetingPointView> Handle(
            CreateMeetingPointCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MeetingPoint>(command);

            await this.appDbContext.MeetingPoints.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MeetingPointView>(entity);
        }
    }
}
