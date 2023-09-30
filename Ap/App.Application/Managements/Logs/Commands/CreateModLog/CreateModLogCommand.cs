#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Logs.ModLogs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Commands.CreateModLog
{
    /// <summary>
    /// 建立 ModLog
    /// </summary>

    public class CreateModLogCommand :  ModLogBase, IRequest<ModLogView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModLogCommandHandler : IRequestHandler<CreateModLogCommand, ModLogView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModLogCommandHandler(
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
        public async Task<ModLogView> Handle(
            CreateModLogCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModLog>(command);

            await this.appDbContext.ModLogs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModLogView>(entity);
        }
    }
}
