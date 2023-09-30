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
using App.Application.Managements.UserSocieties.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserSocieties.Commands.UpdateUserSociety
{
    /// <summary>
    /// 更新  UserSociety
    /// </summary>

    public class UpdateUserSocietyCommand : UserSocietyBase,IRequest<UserSocietyView>
    {
    
        //public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserSocietyCommandHandler : IRequestHandler<UpdateUserSocietyCommand, UserSocietyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateUserSocietyCommandHandler(
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
            UpdateUserSocietyCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.UserSocieties.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserSocietyView>(entity);
        }
    }
}
