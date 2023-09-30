#region

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities.Features;
using App.Utility.Extensions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Application.Managements.Users.Commands.AssignUserRole
{
    /// <summary>
    /// 指派角色給管理員
    /// </summary>
    [MrLogging(IgnoreRequest = false, IgnoreResponse = false)]
    public class AssignUserRoleCommand : IRequest<Unit>
    {
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Guid> RoleIds { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AssignUserRoleCommandHandler
        : IRequestHandler<AssignUserRoleCommand, Unit>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        public AssignUserRoleCommandHandler(
            ILogger<AssignUserRoleCommandHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Unit> Handle(
            AssignUserRoleCommand command,
            CancellationToken cancellationToken
        )
        {
            var userRoleMappings = await this.appDbContext
               .RoleUserMappings
               .Where(
                    e => this.appDbContext.Users
                       .Select(a => a.Id)
                       .Where(id => id == command.UserId)
                       .Contains(e.UserId)
                )
               .ToListAsync(cancellationToken);

            var targetMappings = command.RoleIds
               .Select(
                    x => new RoleUserMapping
                    {
                        RoleId = x,
                        UserId = command.UserId
                    }
                )
               .ToList();

            var diff = userRoleMappings
               .DifferFrom(
                    targetMappings,
                    (x, y) => x.RoleId == y.RoleId
                );

            await this.appDbContext.RoleUserMappings.AddRangeAsync(
                diff.SourceMissingItems,
                cancellationToken
            );

            this.appDbContext.RoleUserMappings
               .RemoveRange(diff.TargetMissingItems);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
