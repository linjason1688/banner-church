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

namespace App.Application.Managements.Users.Commands.DeleteUser
{
    /// <summary>
    /// 刪除  User
    /// </summary>

    public class DeleteUserCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteUserCommandHandler(
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
            DeleteUserCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.Users.RemoveAsync(
                new User()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
