#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysOrganizations.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysOrganizations.Commands.CreateSysOrganization
{
    /// <summary>
    /// 建立 SysOrganization
    /// </summary>

    public class CreateSysOrganizationCommand :  SysOrganizationBase, IRequest<SysOrganizationView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysOrganizationCommandHandler : IRequestHandler<CreateSysOrganizationCommand, SysOrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysOrganizationCommandHandler(
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
        public async Task<SysOrganizationView> Handle(
            CreateSysOrganizationCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysOrganization>(command);

            await this.appDbContext.SysOrganizations.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysOrganizationView>(entity);
        }
    }
}
