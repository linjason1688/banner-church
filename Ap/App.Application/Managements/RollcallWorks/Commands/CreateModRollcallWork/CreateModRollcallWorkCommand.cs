#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.CreateModRollcallWork
{
    /// <summary>
    /// 建立 ModRollcallWork
    /// </summary>

    public class CreateModRollcallWorkCommand :  ModRollcallWorkBase, IRequest<ModRollcallWorkView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModRollcallWorkCommandHandler : IRequestHandler<CreateModRollcallWorkCommand, ModRollcallWorkView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModRollcallWorkCommandHandler(
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
            CreateModRollcallWorkCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModRollcallWork>(command);

            await this.appDbContext.ModRollcallWorks.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModRollcallWorkView>(entity);
        }
    }
}
