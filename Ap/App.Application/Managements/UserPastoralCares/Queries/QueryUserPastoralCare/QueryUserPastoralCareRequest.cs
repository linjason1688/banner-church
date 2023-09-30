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
using App.Application.Managements.UserPastoralCares.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserPastoralCares.Queries.QueryUserPastoralCare
{
    /// <summary>
    /// 分頁查詢 UserPastoralCare
    /// </summary>

    public class QueryUserPastoralCareRequest 
        : PageableQuery, IRequest<Page<UserPastoralCareView>>
    {

        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 牧養類型 對應SystemConfig        type=CareType        顯示 name        value存此欄位 0：新進會員 1：移動 2：身分變更
        /// </summary>
        public string CareType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PastoralTitle { get; set; }

        /// <summary>
        /// 新區域
        /// </summary>
        public string NewArea { get; set; }

        /// <summary>
        /// 舊區域
        /// </summary>
        public string OldArea { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? CareDate { get; set; }

        /// <summary>
        /// 異動日期啟日
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 異動日期迄日
        /// </summary>
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    ///  分頁查詢 UserPastoralCare
    /// </summary>
    public class QueryUserPastoralCareRequestHandler 
        : IRequestHandler<QueryUserPastoralCareRequest, Page<UserPastoralCareView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserPastoralCareRequestHandler(
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
        public async Task<Page<UserPastoralCareView>> Handle(
            QueryUserPastoralCareRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserPastoralCares
 
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id
              .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                .WhereWhenNotEmpty(request.CareType, c => c.CareType == request.CareType)//牧養類型 對應SystemConfigtype=CareType顯示 namevalue存此欄位0：新進會員1：移動2：身分變更
                .WhereWhenNotEmpty(request.PastoralTitle, c => c.PastoralTitle == request.PastoralTitle)//
                .WhereWhenNotEmpty(request.NewArea?.ToString(), c => c.NewArea == request.NewArea)//新區域
                .WhereWhenNotEmpty(request.OldArea?.ToString(), c => c.OldArea == request.OldArea)//舊區域
               .ProjectTo<UserPastoralCareView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
