#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetUsers.Commands.CreateAspnetUser
{
    /// <summary>
    /// 建立 AspnetUser
    /// </summary>

    public class CreateAspnetUserCommand :  AspnetUserBase, IRequest<AspnetUserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetUserCommandHandler : IRequestHandler<CreateAspnetUserCommand, AspnetUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetUserCommandHandler(
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
        public async Task<AspnetUserView> Handle(
            CreateAspnetUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetUser>(command);

            await this.appDbContext.AspnetUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetUserView>(entity);
        }
    }
}
