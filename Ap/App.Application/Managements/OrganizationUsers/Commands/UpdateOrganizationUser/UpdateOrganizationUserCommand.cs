#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.OrganizationUsers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.OrganizationUsers.Commands.UpdateOrganizationUser
{
    /// <summary>
    /// 更新  OrganizationUser
    /// </summary>

    public class UpdateOrganizationUserCommand : OrganizationUserBase,IRequest<OrganizationUserView>
    {
    
        //public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateOrganizationUserCommandHandler : IRequestHandler<UpdateOrganizationUserCommand, OrganizationUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateOrganizationUserCommandHandler(
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
        public async Task<OrganizationUserView> Handle(
            UpdateOrganizationUserCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.OrganizationUsers.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<OrganizationUserView>(entity);
        }
    }
}
