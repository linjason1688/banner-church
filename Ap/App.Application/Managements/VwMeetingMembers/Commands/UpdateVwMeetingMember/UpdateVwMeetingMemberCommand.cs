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
using App.Application.Managements.VwMeetingMembers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Commands.UpdateVwMeetingMember
{
    /// <summary>
    /// 更新  VwMeetingMember
    /// </summary>

    public class UpdateVwMeetingMemberCommand : VwMeetingMemberBase,IRequest<VwMeetingMemberView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMeetingMemberCommandHandler : IRequestHandler<UpdateVwMeetingMemberCommand, VwMeetingMemberView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMeetingMemberCommandHandler(
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
            UpdateVwMeetingMemberCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.VwMeetingMembers.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMeetingMemberView>(entity);
        }
    }
}
