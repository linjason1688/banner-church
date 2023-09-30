#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberLogs.ModMemberLogs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Commands.CreateModMemberLog
{
    /// <summary>
    /// 建立 ModMemberLog
    /// </summary>

    public class CreateModMemberLogCommand :  ModMemberLogBase, IRequest<ModMemberLogView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberLogCommandHandler : IRequestHandler<CreateModMemberLogCommand, ModMemberLogView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberLogCommandHandler(
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
        public async Task<ModMemberLogView> Handle(
            CreateModMemberLogCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberLog>(command);

            await this.appDbContext.ModMemberLogs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberLogView>(entity);
        }
    }
}
