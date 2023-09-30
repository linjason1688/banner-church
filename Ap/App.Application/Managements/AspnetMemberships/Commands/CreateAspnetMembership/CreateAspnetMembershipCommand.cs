#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.AspnetMemberships.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetMemberships.Commands.CreateAspnetMembership
{
    /// <summary>
    /// 建立 AspnetMembership
    /// </summary>

    public class CreateAspnetMembershipCommand :  AspnetMembershipBase, IRequest<AspnetMembershipView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetMembershipCommandHandler : IRequestHandler<CreateAspnetMembershipCommand, AspnetMembershipView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetMembershipCommandHandler(
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
        public async Task<AspnetMembershipView> Handle(
            CreateAspnetMembershipCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetMembership>(command);

            await this.appDbContext.AspnetMemberships.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetMembershipView>(entity);
        }
    }
}
