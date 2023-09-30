#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwAspnetMembershipUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Commands.CreateVwAspnetMembershipuser
{
    /// <summary>
    /// 建立 VwAspnetMembershipuser
    /// </summary>

    public class CreateVwAspnetMembershipuserCommand :  VwAspnetMembershipuserBase, IRequest<VwAspnetMembershipuserView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetMembershipuserCommandHandler : IRequestHandler<CreateVwAspnetMembershipuserCommand, VwAspnetMembershipuserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetMembershipuserCommandHandler(
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
        public async Task<VwAspnetMembershipuserView> Handle(
            CreateVwAspnetMembershipuserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwAspnetMembershipUser>(command);

            await this.appDbContext.VwAspnetMembershipUsers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwAspnetMembershipuserView>(entity);
        }
    }
}
