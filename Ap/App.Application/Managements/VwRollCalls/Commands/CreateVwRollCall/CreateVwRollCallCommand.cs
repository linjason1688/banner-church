#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwRollCalls.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwRollCalls.Commands.CreateVwRollCall
{
    /// <summary>
    /// 建立 VwRollCall
    /// </summary>

    public class CreateVwRollCallCommand :  VwRollCallBase, IRequest<VwRollCallView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwRollCallCommandHandler : IRequestHandler<CreateVwRollCallCommand, VwRollCallView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwRollCallCommandHandler(
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
        public async Task<VwRollCallView> Handle(
            CreateVwRollCallCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwRollCall>(command);

            await this.appDbContext.VwRollCalls.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwRollCallView>(entity);
        }
    }
}
