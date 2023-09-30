#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetUsersInRoles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Commands.CreateVwAspnetUsersInRole
{
    /// <summary>
    /// 建立 VwAspnetUsersInRole
    /// </summary>

    public class CreateVwAspnetUsersInRoleCommand :  VwAspnetUsersInRoleBase, IRequest<VwAspnetUsersInRoleView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetUsersInRoleCommandHandler : IRequestHandler<CreateVwAspnetUsersInRoleCommand, VwAspnetUsersInRoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetUsersInRoleCommandHandler(
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
        public async Task<VwAspnetUsersInRoleView> Handle(
            CreateVwAspnetUsersInRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetUsersInRole>(command);

            await this.appDbContext.VwAspnetUsersInRoles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetUsersInRoleView>(entity);
        }
    }
}
