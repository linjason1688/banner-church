#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.RoleUserMappings.Commands.CreateRoleUserMapping
{
    /// <summary>
    /// 建立 RoleUserMapping
    /// </summary>

    public class CreateRoleUserMappingCommand :  RoleUserMappingBase, IRequest<RoleUserMappingView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateRoleUserMappingCommandHandler : IRequestHandler<CreateRoleUserMappingCommand, RoleUserMappingView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateRoleUserMappingCommandHandler(
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
            CreateRoleUserMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<RoleUserMapping>(command);

            await this.appDbContext.RoleUserMappings.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<RoleUserMappingView>(entity);
        }
    }
}
