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

namespace App.Application.Managements.Privileges.Commands.DeletePrivilege
{
    /// <summary>
    /// 刪除  Privilege
    /// </summary>

    public class DeletePrivilegeCommand : IRequest<Unit>
    {
    
        public Guid? Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeletePrivilegeCommandHandler : IRequestHandler<DeletePrivilegeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeletePrivilegeCommandHandler(
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
            DeletePrivilegeCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.Privileges.RemoveAsync(
                new Privilege()
                {
                    Id = command.Id.Value
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
