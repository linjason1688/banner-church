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
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.UpdateRoleUserMapping
{
    /// <summary>
    /// 更新  RoleUserMapping
    /// </summary>

    public class UpdateRoleUserMappingCommand : RoleUserMappingBase,IRequest<RoleUserMappingView>
    {
       
        public Guid Id { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateRoleUserMappingCommandHandler : IRequestHandler<UpdateRoleUserMappingCommand, RoleUserMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateRoleUserMappingCommandHandler(
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
        public async Task<RoleUserMappingView> Handle(
            UpdateRoleUserMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.RoleUserMappings.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RoleUserMappingView>(entity);
        }
    }
}
