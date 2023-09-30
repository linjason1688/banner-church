#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SecUserRoles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SecUserRoles.Commands.CreateSecUserRole
{
    /// <summary>
    /// 建立 SecUserRole
    /// </summary>

    public class CreateSecUserRoleCommand :  SecUserRoleBase, IRequest<SecUserRoleView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSecUserRoleCommandHandler : IRequestHandler<CreateSecUserRoleCommand, SecUserRoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSecUserRoleCommandHandler(
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
        public async Task<SecUserRoleView> Handle(
            CreateSecUserRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SecUserRole>(command);

            await this.appDbContext.SecUserRoles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SecUserRoleView>(entity);
        }
    }
}
