#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetApplications.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Commands.CreateVwAspnetApplication
{
    /// <summary>
    /// 建立 VwAspnetApplication
    /// </summary>

    public class CreateVwAspnetApplicationCommand :  VwAspnetApplicationBase, IRequest<VwAspnetApplicationView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetApplicationCommandHandler : IRequestHandler<CreateVwAspnetApplicationCommand, VwAspnetApplicationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetApplicationCommandHandler(
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
        public async Task<VwAspnetApplicationView> Handle(
            CreateVwAspnetApplicationCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetApplication>(command);

            await this.appDbContext.VwAspnetApplications.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetApplicationView>(entity);
        }
    }
}
