#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Pastorals.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Pastorals.Commands.CreatePastoral
{
    /// <summary>
    /// 建立 Pastoral
    /// </summary>

    public class CreatePastoralCommand :  PastoralBase, IRequest<PastoralView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralCommandHandler : IRequestHandler<CreatePastoralCommand, PastoralView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralCommandHandler(
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
        public async Task<PastoralView> Handle(
            CreatePastoralCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Pastoral>(command);

            await this.appDbContext.Pastorals.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<PastoralView>(entity);
        }
    }
}
