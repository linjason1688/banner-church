#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Meetings.ModMeetings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Commands.CreateModMeeting
{
    /// <summary>
    /// 建立 ModMeeting
    /// </summary>

    public class CreateModMeetingCommand :  ModMeetingBase, IRequest<ModMeetingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMeetingCommandHandler : IRequestHandler<CreateModMeetingCommand, ModMeetingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMeetingCommandHandler(
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
        public async Task<ModMeetingView> Handle(
            CreateModMeetingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMeeting>(command);

            await this.appDbContext.ModMeetings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMeetingView>(entity);
        }
    }
}
