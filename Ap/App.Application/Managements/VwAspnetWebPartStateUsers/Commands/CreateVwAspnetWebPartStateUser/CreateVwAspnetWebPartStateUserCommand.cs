#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetWebPartStateUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Commands.CreateVwAspnetWebPartStateUser
{
    /// <summary>
    /// 建立 VwAspnetWebPartStateUser
    /// </summary>

    public class CreateVwAspnetWebPartStateUserCommand :  VwAspnetWebPartStateUserBase, IRequest<VwAspnetWebPartStateUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStateUserCommandHandler : IRequestHandler<CreateVwAspnetWebPartStateUserCommand, VwAspnetWebPartStateUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStateUserCommandHandler(
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
        public async Task<VwAspnetWebPartStateUserView> Handle(
            CreateVwAspnetWebPartStateUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetWebPartStateUser>(command);

            await this.appDbContext.VwAspnetWebPartStateUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetWebPartStateUserView>(entity);
        }
    }
}
