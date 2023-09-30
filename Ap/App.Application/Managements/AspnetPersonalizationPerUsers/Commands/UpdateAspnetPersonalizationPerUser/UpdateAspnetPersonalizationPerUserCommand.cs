#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetPersonalizationPerUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Commands.UpdateAspnetPersonalizationPerUser
{
    /// <summary>
    /// 更新  AspnetPersonalizationPerUser
    /// </summary>

    public class UpdateAspnetPersonalizationPerUserCommand : AspnetPersonalizationPerUserBase,IRequest<AspnetPersonalizationPerUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetPersonalizationPerUserCommandHandler : IRequestHandler<UpdateAspnetPersonalizationPerUserCommand, AspnetPersonalizationPerUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetPersonalizationPerUserCommandHandler(
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
        public async Task<AspnetPersonalizationPerUserView> Handle(
            UpdateAspnetPersonalizationPerUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.AspnetPersonalizationPerUsers.FindOneAsync(
                e => e.Id.ToString() == command.Id.ToString(),
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetPersonalizationPerUserView>(entity);
        }
    }
}
