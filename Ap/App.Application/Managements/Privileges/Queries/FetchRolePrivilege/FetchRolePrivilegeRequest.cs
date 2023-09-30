#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Privileges.Dtos;
using App.Utility.Extensions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.Privileges.Queries.FetchRolePrivilege
{
    /// <summary>
    /// 查詢角色權限資料 (Tree)
    /// </summary>
    [MrLogging(IgnoreRequest = false, IgnoreResponse = true)]
    public class FetchRolePrivilegeRequest
        : IRequest<List<PrivilegeNodeView>>
    {
        /// <summary>
        /// 
        /// </summary>

        public Guid? RoleId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchRolePrivilegeHandler
        : IRequestHandler<FetchRolePrivilegeRequest, List<PrivilegeNodeView>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        public FetchRolePrivilegeHandler(
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
        public async Task<List<PrivilegeNodeView>> Handle(
            FetchRolePrivilegeRequest request,
            CancellationToken cancellationToken
        )
        {
            var privileges = await this.appDbContext
               .Privileges
               .ToLimitedListAsync(cancellationToken);

            // fetch
            var authedPrivileges = await this.appDbContext
               .RolePrivilegeMappings
               .Where(e => e.RoleId == request.RoleId)
               .Where(e => e.Enable)
               .ToListAsync(cancellationToken);

            var authedMap = authedPrivileges
               .ToDictionary(g => g.PrivilegeId.ToString(), p => p);

            var root = privileges
               .Select(
                    e =>
                    {
                        var node = this.mapper.Map<PrivilegeNodeView>(e);

                        var authItem = authedMap.SafeGet(node.Id);

                        // 
                        if (null != authItem)
                        {
                            node.Authorized = true;
                            node.ViewGranted = authItem.ViewGranted;
                            node.ModifyGranted = authItem.ModifyGranted;
                            node.DeleteGranted = authItem.DeleteGranted;
                            node.UploadGranted = authItem.UploadGranted;
                            node.DownloadGranted = authItem.DownloadGranted;
                        }

                        return node;
                    }
                )
               .ConvertToNodeTree<PrivilegeNodeView, string>(
                    new PrivilegeNodeView
                    {
                        Key = string.Empty
                    }
                );

            this.BindingNodeLevel(root, 1);

            return root.FlatToList<PrivilegeNodeView, string>();
        }

        private void BindingNodeLevel(PrivilegeNodeView node, int level)
        {
            node.Level = level;

            node.Nodes?.ForEach(
                n =>
                {
                    this.BindingNodeLevel(n, level + 1);
                }
            );
        }
    }
}
