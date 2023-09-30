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
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using System.ComponentModel;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.QueryRoleUserMapping
{
    /// <summary>
    /// 分頁查詢 RoleUserMapping
    /// </summary>

    public class QueryRoleUserMappingRequest
        : PageableQuery, IRequest<Page<RoleUserMappingView>>
    {

        public string Name { get; set; }
        public long? UserId { get; set; }

        public Guid? RoleId { get; set; }

        /// <summary>
        ///  分頁查詢 RoleUserMapping
        /// </summary>
        public class QueryRoleUserMappingRequestHandler
        : IRequestHandler<QueryRoleUserMappingRequest, Page<RoleUserMappingView>>
        {
            private readonly IMapper mapper;

            private readonly IAppDbContext appDbContext;

            /// <summary>
            /// 
            /// </summary>
            public QueryRoleUserMappingRequestHandler(
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
            public async Task<Page<RoleUserMappingView>> Handle(
                QueryRoleUserMappingRequest request,
                CancellationToken cancellationToken
            )
            {
                return await this.appDbContext
                   .RoleUserMappings
                    .WhereWhen(Convert.ToInt64(request.UserId) != 0, c => c.UserId == request.UserId)//設備持有人idUser.id               
                      .WhereWhen(request.RoleId.HasValue, c => c.RoleId == request.RoleId.Value)
                   .ProjectTo<RoleUserMappingView>(this.mapper.ConfigurationProvider)
                   .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                   .ToPageAsync(request);

            }
        }
    }
}
