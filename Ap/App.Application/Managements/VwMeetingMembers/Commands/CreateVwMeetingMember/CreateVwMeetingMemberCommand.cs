#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwMeetingMembers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Commands.CreateVwMeetingMember
{
    /// <summary>
    /// 建立 VwMeetingMember
    /// </summary>

    public class CreateVwMeetingMemberCommand :  VwMeetingMemberBase, IRequest<VwMeetingMemberView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMeetingMemberCommandHandler : IRequestHandler<CreateVwMeetingMemberCommand, VwMeetingMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwMeetingMemberCommandHandler(
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
        public async Task<VwMeetingMemberView> Handle(
            CreateVwMeetingMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwMeetingMember>(command);

            await this.appDbContext.VwMeetingMembers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMeetingMemberView>(entity);
        }
    }
}
