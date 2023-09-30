#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetWebPartStateShareds.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Commands.CreateVwAspnetWebPartStateShared
{
    /// <summary>
    /// 建立 VwAspnetWebPartStateShared
    /// </summary>

    public class CreateVwAspnetWebPartStateSharedCommand :  VwAspnetWebPartStateSharedBase, IRequest<VwAspnetWebPartStateSharedView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStateSharedCommandHandler : IRequestHandler<CreateVwAspnetWebPartStateSharedCommand, VwAspnetWebPartStateSharedView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStateSharedCommandHandler(
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
        public async Task<VwAspnetWebPartStateSharedView> Handle(
            CreateVwAspnetWebPartStateSharedCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetWebPartStateShared>(command);

            await this.appDbContext.VwAspnetWebPartStateShareds.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetWebPartStateSharedView>(entity);
        }
    }
}
