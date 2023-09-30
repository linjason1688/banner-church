using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Infrastructure.Supports;
using App.Utility;
using App.Utility.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;
using Yozian.Extension;

namespace App.Infrastructure.DevSupports.DataSeeding
{
    /// <summary>
    /// </summary>
    [TransientService(typeof(IDevSupport))]
    public class PrivilegesSeedingSupport : DevSupportBase, IDevSupport
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="appDbContext"></param>
        public PrivilegesSeedingSupport(
            IMapper mapper,
            ILogger<PrivilegesSeedingSupport> logger,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.appDbContext = appDbContext;
        }


        /// <inheritdoc />
        public async Task Process(Dictionary<string, object> options, CancellationToken cancellationToken = default)
        {
            var existingPrivileges = await this.appDbContext.Privileges.ToListAsync(cancellationToken);

            var json = ResourceProvider.ReadFile(Path.Join("DevSupports", "Privileges.json"));
            var root = Serialization.Deserialize<PrivilegeNode>(json);

            this.BindParentId(root);

            var privileges = root.FlatToList<PrivilegeNode, string>()
               .Select(
                    n => new Privilege
                    {
                        FunctionId = n.FunctionId,
                        ParentFunctionId = n.ParentFunctionId,
                        Name = n.Name,
                        Sort = n.Sort,
                        LinkType = n.LinkType,
                        QueryParams = n.QueryParams,
                        Comment = n.Comment
                    }
                )
               .ToList();

            var diff = existingPrivileges
               .DifferFrom(
                    privileges,
                    (a, b) => a.FunctionId == b.FunctionId
                );

            diff.MatchedItems.ForEach(
                d =>
                {
                    //
                    d.Source.ParentFunctionId = d.Target.ParentFunctionId;
                    d.Source.Name = d.Target.Name;
                    d.Source.LinkType = d.Target.LinkType;
                    d.Source.QueryParams = d.Target.QueryParams;
                    d.Source.Comment = d.Target.Comment;
                }
            );

            foreach (var item in diff.TargetMissingItems)
            {
                this.appDbContext.Privileges.Remove(item);
            }

            await this.appDbContext.Privileges.AddRangeAsync(diff.SourceMissingItems, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);
        }


        /// <summary>
        /// auto bind parent key to children
        /// </summary>
        /// <param name="node"></param>
        private void BindParentId(PrivilegeNode node)
        {
            node.Nodes?.ForEach(
                c =>
                {
                    c.ParentKey = node.Key;
                    this.BindParentId(c);
                }
            );
        }
    }
}
