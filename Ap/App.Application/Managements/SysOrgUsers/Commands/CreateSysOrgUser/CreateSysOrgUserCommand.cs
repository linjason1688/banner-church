#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysOrgUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysOrgUsers.Commands.CreateSysOrgUser
{
    /// <summary>
    /// 建立 SysOrgUser
    /// </summary>

    public class CreateSysOrgUserCommand :  SysOrgUserBase, IRequest<SysOrgUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysOrgUserCommandHandler : IRequestHandler<CreateSysOrgUserCommand, SysOrgUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysOrgUserCommandHandler(
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
        public async Task<SysOrgUserView> Handle(
            CreateSysOrgUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysOrgUser>(command);

            await this.appDbContext.SysOrgUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysOrgUserView>(entity);
        }
    }
}
