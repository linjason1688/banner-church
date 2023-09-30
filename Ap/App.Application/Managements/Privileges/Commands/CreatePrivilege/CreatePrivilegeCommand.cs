#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Privileges.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Privileges.Commands.CreatePrivilege
{
    /// <summary>
    /// 建立 Privilege
    /// </summary>

    public class CreatePrivilegeCommand :  PrivilegeBase, IRequest<PrivilegeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreatePrivilegeCommandHandler : IRequestHandler<CreatePrivilegeCommand, PrivilegeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreatePrivilegeCommandHandler(
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
        public async Task<PrivilegeView> Handle(
            CreatePrivilegeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Privilege>(command);

            await this.appDbContext.Privileges.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<PrivilegeView>(entity);
        }
    }
}
