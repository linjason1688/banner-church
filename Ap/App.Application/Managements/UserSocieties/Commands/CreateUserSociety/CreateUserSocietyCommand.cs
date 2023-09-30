#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.UserSocieties.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserSocieties.Commands.CreateUserSociety
{
    /// <summary>
    /// 建立 UserSociety
    /// </summary>

    public class CreateUserSocietyCommand :  UserSocietyBase, IRequest<UserSocietyView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserSocietyCommandHandler : IRequestHandler<CreateUserSocietyCommand, UserSocietyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateUserSocietyCommandHandler(
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
        public async Task<UserSocietyView> Handle(
            CreateUserSocietyCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<UserSociety>(command);

            await this.appDbContext.UserSocieties.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserSocietyView>(entity);
        }
    }
}
