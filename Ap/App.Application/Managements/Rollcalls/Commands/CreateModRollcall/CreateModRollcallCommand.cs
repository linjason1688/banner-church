#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Rollcalls.ModRollcalls.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Commands.CreateModRollcall
{
    /// <summary>
    /// 建立 ModRollcall
    /// </summary>

    public class CreateModRollcallCommand :  ModRollcallBase, IRequest<ModRollcallView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModRollcallCommandHandler : IRequestHandler<CreateModRollcallCommand, ModRollcallView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModRollcallCommandHandler(
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
        public async Task<ModRollcallView> Handle(
            CreateModRollcallCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModRollcall>(command);

            await this.appDbContext.ModRollcalls.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModRollcallView>(entity);
        }
    }
}
