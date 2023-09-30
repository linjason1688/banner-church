#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.OrganizationUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.OrganizationUsers.Commands.CreateOrganizationUser
{
    /// <summary>
    /// 建立 OrganizationUser
    /// </summary>

    public class CreateOrganizationUserCommand :  OrganizationUserBase, IRequest<OrganizationUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateOrganizationUserCommandHandler : IRequestHandler<CreateOrganizationUserCommand, OrganizationUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateOrganizationUserCommandHandler(
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
        public async Task<OrganizationUserView> Handle(
            CreateOrganizationUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<OrganizationUser>(command);

            await this.appDbContext.OrganizationUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<OrganizationUserView>(entity);
        }
    }
}
