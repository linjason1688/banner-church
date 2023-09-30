#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.CreateModMemberMinisterLog
{
    /// <summary>
    /// 建立 ModMemberMinisterLog
    /// </summary>

    public class CreateModMemberMinisterLogCommand :  ModMemberMinisterLogBase, IRequest<ModMemberMinisterLogView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberMinisterLogCommandHandler : IRequestHandler<CreateModMemberMinisterLogCommand, ModMemberMinisterLogView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberMinisterLogCommandHandler(
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
            CreateModMemberMinisterLogCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberMinisterLog>(command);

            await this.appDbContext.ModMemberMinisterLogs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberMinisterLogView>(entity);
        }
    }
}
