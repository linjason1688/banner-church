#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryMeetingUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Commands.CreateMinistryMeetingUser
{
    /// <summary>
    /// 建立 MinistryMeetingUser
    /// </summary>

    public class CreateMinistryMeetingUserCommand :  MinistryMeetingUserBase, IRequest<MinistryMeetingUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryMeetingUserCommandHandler : IRequestHandler<CreateMinistryMeetingUserCommand, MinistryMeetingUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryMeetingUserCommandHandler(
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
        public async Task<MinistryMeetingUserView> Handle(
            CreateMinistryMeetingUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryMeetingUser>(command);

            await this.appDbContext.MinistryMeetingUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryMeetingUserView>(entity);
        }
    }
}
