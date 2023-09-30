#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MeetingMembers.ModMeetingMembers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.CreateModMeetingMember
{
    /// <summary>
    /// 建立 ModMeetingMember
    /// </summary>

    public class CreateModMeetingMemberCommand :  ModMeetingMemberBase, IRequest<ModMeetingMemberView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMeetingMemberCommandHandler : IRequestHandler<CreateModMeetingMemberCommand, ModMeetingMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMeetingMemberCommandHandler(
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
        public async Task<ModMeetingMemberView> Handle(
            CreateModMeetingMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMeetingMember>(command);

            await this.appDbContext.ModMeetingMembers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMeetingMemberView>(entity);
        }
    }
}
