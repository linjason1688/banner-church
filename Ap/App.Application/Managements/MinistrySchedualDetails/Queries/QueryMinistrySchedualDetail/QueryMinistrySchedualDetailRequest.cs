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
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Queries.QueryMinistryScheduleDetail
{
    /// <summary>
    /// 分頁查詢 MinistryScheduleDetail
    /// </summary>

    public class QueryMinistryScheduleDetailRequest 
        : PageableQuery, IRequest<Page<MinistryScheduleDetailView>>
    {

        /// <summary>
        ///  排程明細id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  MinistrySchedule.Id
        /// </summary>
        public long MinistryScheduleId { get; set; }

        /// <summary>
        ///  堂表名稱 例如：第一堂
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  描述  例如 09:00~10:00
        /// </summary>
        public string Description { get; set; }
        // [DataMember]

    }

    /// <summary>
    ///  分頁查詢 MinistryScheduleDetail
    /// </summary>
    public class QueryMinistryScheduleDetailRequestHandler 
        : IRequestHandler<QueryMinistryScheduleDetailRequest, Page<MinistryScheduleDetailView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryScheduleDetailRequestHandler(
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
        public async Task<Page<MinistryScheduleDetailView>> Handle(
            QueryMinistryScheduleDetailRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryScheduleDetails
               .WhereWhenNotEmpty(request.Id.ToString(), c => c.Id == request.Id)//排程明細id
                .WhereWhenNotEmpty(request.MinistryScheduleId.ToString(), c => c.MinistryScheduleId == request.MinistryScheduleId)//MinistrySchedule.Id
                .WhereWhenNotEmpty(request.Name?.ToString(), c => c.Name == request.Name)//堂表名稱 例如：第一堂
                .WhereWhenNotEmpty(request.Description?.ToString(), c => c.Description == request.Description)//描述  例如 09:00~10:00

               .ProjectTo<MinistryScheduleDetailView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
