#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.PastoralMeetings.Commands.CreatePastoralMeeting
{
    /// <summary>
    /// 建立 PastoralMeeting
    /// </summary>

    public class CreatePastoralMeetingCommand :  PastoralMeetingBase, IRequest<PastoralMeetingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralMeetingCommandHandler : IRequestHandler<CreatePastoralMeetingCommand, PastoralMeetingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralMeetingCommandHandler(
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
        public async Task<PastoralMeetingView> Handle(
            CreatePastoralMeetingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<PastoralMeeting>(command);

            await this.appDbContext.PastoralMeetings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<PastoralMeetingView>(entity);
        }
    }
}
