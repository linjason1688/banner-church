#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetProfiles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Commands.CreateVwAspnetProfile
{
    /// <summary>
    /// 建立 VwAspnetProfile
    /// </summary>

    public class CreateVwAspnetProfileCommand :  VwAspnetProfileBase, IRequest<VwAspnetProfileView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetProfileCommandHandler : IRequestHandler<CreateVwAspnetProfileCommand, VwAspnetProfileView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetProfileCommandHandler(
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
        public async Task<VwAspnetProfileView> Handle(
            CreateVwAspnetProfileCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetProfile>(command);

            await this.appDbContext.VwAspnetProfiles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetProfileView>(entity);
        }
    }
}
