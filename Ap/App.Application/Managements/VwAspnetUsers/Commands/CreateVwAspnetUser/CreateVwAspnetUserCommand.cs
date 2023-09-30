#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Commands.CreateVwAspnetUser
{
    /// <summary>
    /// 建立 VwAspnetUser
    /// </summary>

    public class CreateVwAspnetUserCommand :  VwAspnetUserBase, IRequest<VwAspnetUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetUserCommandHandler : IRequestHandler<CreateVwAspnetUserCommand, VwAspnetUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetUserCommandHandler(
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
        public async Task<VwAspnetUserView> Handle(
            CreateVwAspnetUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetUser>(command);

            await this.appDbContext.VwAspnetUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetUserView>(entity);
        }
    }
}
