#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysSeedIdentities.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Commands.CreateSysSeedIdentity
{
    /// <summary>
    /// 建立 SysSeedIdentity
    /// </summary>

    public class CreateSysSeedIdentityCommand :  SysSeedIdentityBase, IRequest<SysSeedIdentityView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSeedIdentityCommandHandler : IRequestHandler<CreateSysSeedIdentityCommand, SysSeedIdentityView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysSeedIdentityCommandHandler(
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
        public async Task<SysSeedIdentityView> Handle(
            CreateSysSeedIdentityCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysSeedIdentity>(command);

            await this.appDbContext.SysSeedIdentities.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysSeedIdentityView>(entity);
        }
    }
}
