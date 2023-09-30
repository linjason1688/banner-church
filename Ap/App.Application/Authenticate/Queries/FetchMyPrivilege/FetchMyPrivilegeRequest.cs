#region

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yozian.Extension;

#endregion

namespace App.Application.Authenticate.Queries.FetchMyPrivilege
{
    /// <summary>
    /// </summary>
    [MrLogging(IgnoreRequest = false, IgnoreResponse = true)]
    public class FetchMyPrivilegeRequest
        : IRequest<List<PrivilegeNode>>
    {
    }

    /// <summary>
    /// </summary>
    public class FetchMyPrivilegeRequestHandler
        : IRequestHandler<FetchMyPrivilegeRequest, List<PrivilegeNode>>
    {
        private readonly IAppCacheService appCacheService;
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        /// <summary>
        /// </summary>
        public FetchMyPrivilegeRequestHandler(
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService,
            IAppCacheService appCacheService
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
            this.appCacheService = appCacheService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<List<PrivilegeNode>> Handle(
            FetchMyPrivilegeRequest request,
            CancellationToken cancellationToken
        )
        {
            var identity = this.authService.Identity;

            var privileges = await this.appCacheService
               .GetPrivilegesAsync(cancellationToken: cancellationToken);

            var rpMapping = await this.appCacheService
               .GetRolePrivilegeMappingAsync(cancellationToken: cancellationToken);

            var myRoleIds = await this.appDbContext.RoleUserMappings
               .Where(
                    e => this.appDbContext.Users.Where(a => a.UserNo == identity.Account)
                       .Select(a => a.Id)
                       .Contains(e.UserId)
                )
               .Select(e => e.RoleId)
               .ToListAsync(cancellationToken);

            var availablePrivilegeIds = rpMapping
               .Where(m => myRoleIds.Contains(m.RoleId))
               .Where(m => m.Enable)
               .Select(m => m.PrivilegeId)
               .Distinct()
               .ToList();

            var availablePrivileges = availablePrivilegeIds
               .Join(
                    privileges,
                    pId => pId,
                    p => p.Id,
                    (pId, p) => p
                )
               .Select(
                    e =>
                    {
                        var n = this.mapper.Map<PrivilegeNode>(e);

                        n.ParentKey ??= string.Empty;

                        return n;
                    }
                )
               .OrderBy(p => p.FunctionId)
               .ThenBy(p => p.Sort)
               .ToList();

            var root = availablePrivileges.ConvertToNodeTree<PrivilegeNode, string>(
                new PrivilegeNode
                {
                    Key = string.Empty
                }
            );

            BindingNodeLevel(root, 1);

            return root.FlatToList<PrivilegeNode, string>();
        }


        private void BindingNodeLevel(PrivilegeNode node, int level)
        {
            node.Level = level;

            node.Nodes.ForEach(
                n =>
                {
                    this.BindingNodeLevel(n, level + 1);
                }
            );
        }
    }
}
