#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Groupleaders.ModGroupleaders.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Commands.CreateModGroupleader
{
    /// <summary>
    /// 建立 ModGroupleader
    /// </summary>

    public class CreateModGroupleaderCommand :  ModGroupleaderBase, IRequest<ModGroupleaderView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModGroupleaderCommandHandler : IRequestHandler<CreateModGroupleaderCommand, ModGroupleaderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModGroupleaderCommandHandler(
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
        public async Task<ModGroupleaderView> Handle(
            CreateModGroupleaderCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModGroupleader>(command);

            await this.appDbContext.ModGroupleaders.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModGroupleaderView>(entity);
        }
    }
}
