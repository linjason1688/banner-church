#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetPaths.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetPaths.Commands.CreateAspnetPath
{
    /// <summary>
    /// 建立 AspnetPath
    /// </summary>

    public class CreateAspnetPathCommand :  AspnetPathBase, IRequest<AspnetPathView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetPathCommandHandler : IRequestHandler<CreateAspnetPathCommand, AspnetPathView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetPathCommandHandler(
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
        public async Task<AspnetPathView> Handle(
            CreateAspnetPathCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetPath>(command);

            await this.appDbContext.AspnetPaths.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetPathView>(entity);
        }
    }
}
