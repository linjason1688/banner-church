#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetPersonalizationAllUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Commands.CreateAspnetPersonalizationAllUser
{
    /// <summary>
    /// 建立 AspnetPersonalizationAllUser
    /// </summary>

    public class CreateAspnetPersonalizationAllUserCommand :  AspnetPersonalizationAllUserBase, IRequest<AspnetPersonalizationAllUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetPersonalizationAllUserCommandHandler : IRequestHandler<CreateAspnetPersonalizationAllUserCommand, AspnetPersonalizationAllUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetPersonalizationAllUserCommandHandler(
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
        public async Task<AspnetPersonalizationAllUserView> Handle(
            CreateAspnetPersonalizationAllUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetPersonalizationAllUser>(command);

            await this.appDbContext.AspnetPersonalizationAllUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetPersonalizationAllUserView>(entity);
        }
    }
}
