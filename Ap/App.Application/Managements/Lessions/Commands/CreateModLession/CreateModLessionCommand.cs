#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Lessions.ModLessions.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Commands.CreateModLession
{
    /// <summary>
    /// 建立 ModLession
    /// </summary>

    public class CreateModLessionCommand :  ModLessionBase, IRequest<ModLessionView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionCommandHandler : IRequestHandler<CreateModLessionCommand, ModLessionView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionCommandHandler(
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
        public async Task<ModLessionView> Handle(
            CreateModLessionCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModLession>(command);

            await this.appDbContext.ModLessions.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModLessionView>(entity);
        }
    }
}
