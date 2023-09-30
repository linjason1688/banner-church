#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetWebPartStatePaths.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Commands.CreateVwAspnetWebPartStatePath
{
    /// <summary>
    /// 建立 VwAspnetWebPartStatePath
    /// </summary>

    public class CreateVwAspnetWebPartStatePathCommand :  VwAspnetWebPartStatePathBase, IRequest<VwAspnetWebPartStatePathView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStatePathCommandHandler : IRequestHandler<CreateVwAspnetWebPartStatePathCommand, VwAspnetWebPartStatePathView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStatePathCommandHandler(
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
        public async Task<VwAspnetWebPartStatePathView> Handle(
            CreateVwAspnetWebPartStatePathCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetWebPartStatePath>(command);

            await this.appDbContext.VwAspnetWebPartStatePaths.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetWebPartStatePathView>(entity);
        }
    }
}
