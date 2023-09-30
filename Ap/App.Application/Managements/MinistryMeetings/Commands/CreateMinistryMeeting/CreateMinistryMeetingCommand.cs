#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryMeetings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryMeetings.Commands.CreateMinistryMeeting
{
    /// <summary>
    /// 建立 MinistryMeeting
    /// </summary>

    public class CreateMinistryMeetingCommand :  MinistryMeetingBase, IRequest<MinistryMeetingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryMeetingCommandHandler : IRequestHandler<CreateMinistryMeetingCommand, MinistryMeetingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryMeetingCommandHandler(
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
        public async Task<MinistryMeetingView> Handle(
            CreateMinistryMeetingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryMeeting>(command);

            await this.appDbContext.MinistryMeetings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryMeetingView>(entity);
        }
    }
}
