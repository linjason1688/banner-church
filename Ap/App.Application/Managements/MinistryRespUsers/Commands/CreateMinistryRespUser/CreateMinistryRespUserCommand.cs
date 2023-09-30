#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryRespUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Commands.CreateMinistryRespUser
{
    /// <summary>
    /// 建立 MinistryRespUser
    /// </summary>

    public class CreateMinistryRespUserCommand :  MinistryRespUserBase, IRequest<MinistryRespUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryRespUserCommandHandler : IRequestHandler<CreateMinistryRespUserCommand, MinistryRespUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryRespUserCommandHandler(
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
        public async Task<MinistryRespUserView> Handle(
            CreateMinistryRespUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryRespUser>(command);

            await this.appDbContext.MinistryRespUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryRespUserView>(entity);
        }
    }
}
