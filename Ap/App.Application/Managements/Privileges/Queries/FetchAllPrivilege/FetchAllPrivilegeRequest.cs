#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
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
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Privileges.Queries.FetchAllPrivilege
{
    /// <summary>
    /// 查詢  Privilege 所有資料
    /// </summary>

    public class FetchAllPrivilegeRequest
        : IRequest<List<PrivilegeView>>, ILimitedFetch
    {
        /// <inheritdoc />

        public int? Limit { get; set; }

        public Guid? Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPrivilegeHandler
        : IRequestHandler<FetchAllPrivilegeRequest, List<PrivilegeView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllPrivilegeHandler(
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
        public async Task<List<PrivilegeView>> Handle(
            FetchAllPrivilegeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .Privileges
               .WhereWhen(request.Id.HasValue, c => c.Id == request.Id.Value)
               .ApplyLimitConstraint(request)
               .ProjectTo<PrivilegeView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
