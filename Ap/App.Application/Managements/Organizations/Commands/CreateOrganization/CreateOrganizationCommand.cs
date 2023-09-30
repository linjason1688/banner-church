#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Organizations.Commands.CreateOrganization
{
    /// <summary>
    /// 建立 Organization
    /// </summary>

    public class CreateOrganizationCommand :  OrganizationBase, IRequest<OrganizationView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, OrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateOrganizationCommandHandler(
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
        public async Task<OrganizationView> Handle(
            CreateOrganizationCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Organization>(command);

            await this.appDbContext.Organizations.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<OrganizationView>(entity);
        }
    }
}
