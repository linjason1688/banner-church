#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SecRoles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SecRoles.Commands.CreateSecRole
{
    /// <summary>
    /// 建立 SecRole
    /// </summary>

    public class CreateSecRoleCommand :  SecRoleBase, IRequest<SecRoleView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSecRoleCommandHandler : IRequestHandler<CreateSecRoleCommand, SecRoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSecRoleCommandHandler(
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
        public async Task<SecRoleView> Handle(
            CreateSecRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SecRole>(command);

            await this.appDbContext.SecRoles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SecRoleView>(entity);
        }
    }
}
