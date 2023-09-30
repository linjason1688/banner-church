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
using App.Application.Managements.AspnetPaths.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetPaths.Commands.UpdateAspnetPath
{
    /// <summary>
    /// 更新  AspnetPath
    /// </summary>

    public class UpdateAspnetPathCommand : AspnetPathBase,IRequest<AspnetPathView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetPathCommandHandler : IRequestHandler<UpdateAspnetPathCommand, AspnetPathView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetPathCommandHandler(
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
            UpdateAspnetPathCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.AspnetPaths.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetPathView>(entity);
        }
    }
}
