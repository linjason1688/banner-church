#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserPastoralCares.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserPastoralCares.Commands.CreateUserPastoralCare
{
    /// <summary>
    /// 建立 UserPastoralCare
    /// </summary>

    public class CreateUserPastoralCareCommand :  UserPastoralCareBase, IRequest<UserPastoralCareView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserPastoralCareCommandHandler : IRequestHandler<CreateUserPastoralCareCommand, UserPastoralCareView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserPastoralCareCommandHandler(
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
        public async Task<UserPastoralCareView> Handle(
            CreateUserPastoralCareCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserPastoralCare>(command);

            await this.appDbContext.UserPastoralCares.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserPastoralCareView>(entity);
        }
    }
}
