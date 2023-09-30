#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.PastoralMeetingUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Commands.CreatePastoralMeetingUser
{
    /// <summary>
    /// 建立 PastoralMeetingUser
    /// </summary>

    public class CreatePastoralMeetingUserCommand :  PastoralMeetingUserBase, IRequest<PastoralMeetingUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralMeetingUserCommandHandler : IRequestHandler<CreatePastoralMeetingUserCommand, PastoralMeetingUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralMeetingUserCommandHandler(
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
        public async Task<PastoralMeetingUserView> Handle(
            CreatePastoralMeetingUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<PastoralMeetingUser>(command);

            await this.appDbContext.PastoralMeetingUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<PastoralMeetingUserView>(entity);
        }
    }
}
