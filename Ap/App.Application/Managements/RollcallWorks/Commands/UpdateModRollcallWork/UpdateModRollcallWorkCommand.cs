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
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.UpdateModRollcallWork
{
    /// <summary>
    /// 更新  ModRollcallWork
    /// </summary>

    public class UpdateModRollcallWorkCommand : ModRollcallWorkBase,IRequest<ModRollcallWorkView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModRollcallWorkCommandHandler : IRequestHandler<UpdateModRollcallWorkCommand, ModRollcallWorkView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModRollcallWorkCommandHandler(
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
        public async Task<ModRollcallWorkView> Handle(
            UpdateModRollcallWorkCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModRollcallWorks.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModRollcallWorkView>(entity);
        }
    }
}
