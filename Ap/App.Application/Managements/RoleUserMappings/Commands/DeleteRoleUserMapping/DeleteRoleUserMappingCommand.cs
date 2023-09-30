#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.DeleteRoleUserMapping
{
    /// <summary>
    /// 刪除  RoleUserMapping
    /// </summary>

    public class DeleteRoleUserMappingCommand : IRequest<Unit>
    {

        public Guid Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteRoleUserMappingCommandHandler : IRequestHandler<DeleteRoleUserMappingCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteRoleUserMappingCommandHandler(
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
        public async Task<Unit> Handle(
            DeleteRoleUserMappingCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.RoleUserMappings.RemoveAsync(
                new RoleUserMapping()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
