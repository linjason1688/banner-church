#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SecUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SecUsers.Commands.CreateSecUser
{
    /// <summary>
    /// 建立 SecUser
    /// </summary>

    public class CreateSecUserCommand :  SecUserBase, IRequest<SecUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSecUserCommandHandler : IRequestHandler<CreateSecUserCommand, SecUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSecUserCommandHandler(
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
        public async Task<SecUserView> Handle(
            CreateSecUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SecUser>(command);

            await this.appDbContext.SecUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SecUserView>(entity);
        }
    }
}
