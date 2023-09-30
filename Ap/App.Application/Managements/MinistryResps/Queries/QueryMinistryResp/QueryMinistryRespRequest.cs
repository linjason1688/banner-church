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
using App.Application.Managements.MinistryResps.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.QueryMinistryResp
{
    /// <summary>
    /// 分頁查詢 MinistryResp
    /// </summary>

    public class QueryMinistryRespRequest 
        : PageableQuery, IRequest<Page<MinistryRespView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 事工團.Id
        /// </summary>
        public long? MinistryId { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        public int? Seq { get; set; }

        /// <summary>
        /// 事工團職份名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否管理職是否管理職        對應type=IsYN        顯示 name        value存此欄位 0：N 1：Y
        /// </summary>
        public string ManageType { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MinistryResp
    /// </summary>
    public class QueryMinistryRespRequestHandler 
        : IRequestHandler<QueryMinistryRespRequest, Page<MinistryRespView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryRespRequestHandler(
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
        public async Task<Page<MinistryRespView>> Handle(
            QueryMinistryRespRequest request,
            CancellationToken cancellationToken
        )
        {
            
            return await this.appDbContext
                .MinistryResps
                .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id)//事工團職分明細主檔id
                .WhereWhen(Convert.ToInt64(request.MinistryId) != 0, c => c.MinistryId == request.MinistryId)//事工團.Id
                .WhereWhen(Convert.ToInt64(request.Seq) != 0, c => c.Seq == request.Seq)//順序 由小到大1-6……7-8-9-10
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//事工團職份名稱
                .WhereWhenNotEmpty(request.ManageType?.ToString(), c => c.ManageType == request.ManageType)//是否管理職對應type=IsYN顯示 namevalue存此欄位0：N1：Y
                .ProjectTo<MinistryRespView>(this.mapper.ConfigurationProvider)
                .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                .ToPageAsync(request);
        }
    }
}
