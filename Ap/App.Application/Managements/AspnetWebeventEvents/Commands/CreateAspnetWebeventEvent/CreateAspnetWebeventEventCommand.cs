#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetWebeventEvents.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Commands.CreateAspnetWebeventEvent
{
    /// <summary>
    /// 建立 AspnetWebeventEvent
    /// </summary>

    public class CreateAspnetWebeventEventCommand :  AspnetWebeventEventBase, IRequest<AspnetWebeventEventView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetWebeventEventCommandHandler : IRequestHandler<CreateAspnetWebeventEventCommand, AspnetWebeventEventView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetWebeventEventCommandHandler(
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
        public async Task<AspnetWebeventEventView> Handle(
            CreateAspnetWebeventEventCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetWebEventEvent>(command);

            await this.appDbContext.AspnetWebEventEvents.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetWebeventEventView>(entity);
        }
    }
}
