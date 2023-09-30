#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.$BaseNamespace$$Feature$.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Commands.Create$Target$
{
    /// <summary>
    /// 建立 $Target$
    /// </summary>

    public class Create$Target$Command :  $Target$Base, IRequest<$Target$View>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class Create$Target$CommandHandler : IRequestHandler<Create$Target$Command, $Target$View>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public Create$Target$CommandHandler(
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
        public async Task<$Target$View> Handle(
            Create$Target$Command command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<$Target$>(command);

            await this.appDbContext.$Feature$.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<$Target$View>(entity);
        }
    }
}
