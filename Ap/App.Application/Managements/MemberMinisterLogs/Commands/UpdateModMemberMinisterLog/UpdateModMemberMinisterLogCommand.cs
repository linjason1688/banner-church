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
using App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.UpdateModMemberMinisterLog
{
    /// <summary>
    /// 更新  ModMemberMinisterLog
    /// </summary>

    public class UpdateModMemberMinisterLogCommand : ModMemberMinisterLogBase,IRequest<ModMemberMinisterLogView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberMinisterLogCommandHandler : IRequestHandler<UpdateModMemberMinisterLogCommand, ModMemberMinisterLogView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberMinisterLogCommandHandler(
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
        public async Task<ModMemberMinisterLogView> Handle(
            UpdateModMemberMinisterLogCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModMemberMinisterLogs.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberMinisterLogView>(entity);
        }
    }
}
