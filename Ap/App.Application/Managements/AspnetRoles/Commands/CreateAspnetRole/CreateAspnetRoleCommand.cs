#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetRoles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetRoles.Commands.CreateAspnetRole
{
    /// <summary>
    /// 建立 AspnetRole
    /// </summary>

    public class CreateAspnetRoleCommand :  AspnetRoleBase, IRequest<AspnetRoleView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetRoleCommandHandler : IRequestHandler<CreateAspnetRoleCommand, AspnetRoleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetRoleCommandHandler(
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
        public async Task<AspnetRoleView> Handle(
            CreateAspnetRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetRole>(command);

            await this.appDbContext.AspnetRoles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetRoleView>(entity);
        }
    }
}
