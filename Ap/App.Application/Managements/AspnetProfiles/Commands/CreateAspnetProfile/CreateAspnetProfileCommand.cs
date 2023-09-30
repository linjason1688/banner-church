#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetProfiles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetProfiles.Commands.CreateAspnetProfile
{
    /// <summary>
    /// 建立 AspnetProfile
    /// </summary>

    public class CreateAspnetProfileCommand :  AspnetProfileBase, IRequest<AspnetProfileView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetProfileCommandHandler : IRequestHandler<CreateAspnetProfileCommand, AspnetProfileView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetProfileCommandHandler(
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
        public async Task<AspnetProfileView> Handle(
            CreateAspnetProfileCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetProfile>(command);

            await this.appDbContext.AspnetProfiles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetProfileView>(entity);
        }
    }
}
