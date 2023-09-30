#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Privileges.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using App.Application.Managements.Users.Dtos;
using Yozian.Extension;


#endregion

namespace App.Application.Managements.Privileges.Queries.QueryPrivilege
{
    /// <summary>
    /// 分頁查詢 Privilege
    /// </summary>


    public class QueryUserPrivilegeRequest
        : IRequest<List<PrivilegeView>>, ILimitedFetch
    {

        public long? UserId { get; set; }
        public string Name { get; set; }

        public int? Limit { get; set; }
    }

    //public class SignListCommandRequestHandler : IRequestHandler<SignListCommand, Page<SignListResponse>>
    /// <summary>
    ///  分頁查詢 Privilege
    /// </summary>
    public class QueryUserPrivilegeRequestHandler
        : IRequestHandler<QueryUserPrivilegeRequest, List<PrivilegeView>>
    {
        private readonly IMapper mapper;
        private readonly ILogger<QueryUserPrivilegeRequestHandler> logger;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        public QueryUserPrivilegeRequestHandler(IMapper mapper, IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<PrivilegeView>> Handle(
            QueryUserPrivilegeRequest request,
            CancellationToken cancellationToken
        )
        {
            var lst = await (from x in this.appDbContext.RoleUserMappings.WhereWhen(request.UserId.HasValue, c => c.UserId == request.UserId)
                             from y in this.appDbContext.Roles
                             from w in this.appDbContext.RolePrivilegeMappings
                             from z in this.appDbContext.Privileges
                             where x.RoleId == y.Id && y.Id == w.RoleId && w.PrivilegeId == z.Id
                             select new PrivilegeView
                             {
                                 Name = z.Name,
                                 LinkType = z.LinkType,
                                 FunctionId = z.FunctionId,
                                 ParentFunctionId = z.ParentFunctionId,
                                 Comment = z.Comment

                             })
                             .ToListAsync(cancellationToken);


            return lst;
        }
    }
}
