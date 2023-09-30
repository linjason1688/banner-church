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
using App.Application.Managements.MinistryMeetings.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.MinistryMeetings.Queries.QueryMinistryMeeting
{
    /// <summary>
    /// 分頁查詢 MinistryMeeting
    /// </summary>

    public class QueryMinistryMeetingRequest 
        : PageableQuery, IRequest<Page<MinistryMeetingView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Ministry.Id
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        /// 小組聚會每周哪一天
        /// </summary>
        public string MeetingDayOfWeek { get; set; }

        /// <summary>
        /// 聚會時間
        /// </summary>
        public string MeetingTime { get; set; }

        /// <summary>
        /// 聚會地點
        /// </summary>
        public string MeetingAddress { get; set; }

        /// <summary>
        /// 聚會日期
        /// </summary>
        public DateTime? MeetingDay { get; set; }

        /// <summary>
        /// 是否為外展對應SystemConfigtype=IsNY顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsExp { get; set; }

        /// <summary>
        /// 是否可查詢，否表示隱藏小組
        /// </summary>
        public string IsSearchable { get; set; }

        /// <summary>
        /// 聚會狀態對應SystemConfigtype=MeetType顯示 namevalue存此欄位0：尚未開始1：正常舉行2：停辦
        /// </summary>
        public string MeetType { get; set; }
    }

    /// <summary>
    ///  分頁查詢 MinistryMeeting
    /// </summary>
    public class QueryMinistryMeetingRequestHandler 
        : IRequestHandler<QueryMinistryMeetingRequest, Page<MinistryMeetingView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryMeetingRequestHandler(
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
        public async Task<Page<MinistryMeetingView>> Handle(
            QueryMinistryMeetingRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryMeetings
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//
              .WhereWhen(Convert.ToInt64(request.MinistryId ) != 0, c => c.MinistryId == request.MinistryId )//Ministry.Id
                .WhereWhenNotEmpty(request.MeetingDayOfWeek?.ToString(), c => c.MeetingDayOfWeek == request.MeetingDayOfWeek)//小組聚會每周哪一天
                .WhereWhenNotEmpty(request.MeetingTime?.ToString(), c => c.MeetingTime == request.MeetingTime)//聚會時間
                .WhereWhenNotEmpty(request.MeetingAddress?.ToString(), c => c.MeetingAddress == request.MeetingAddress)//聚會地點
                .WhereWhenNotEmpty(request.MeetingDay.ToString(), c => c.MeetingDay == request.MeetingDay)//聚會日期
                .WhereWhenNotEmpty(request.IsExp, c => c.IsExp == request.IsExp)//是否為外展對應SystemConfigtype=IsNY顯示 namevalue存此欄位0：N1：Y
                .WhereWhenNotEmpty(request.IsSearchable, c => c.IsSearchable == request.IsSearchable)//是否可查詢，否表示隱藏小組
                .WhereWhenNotEmpty(request.MeetType, c => c.MeetType == request.MeetType)//聚會狀態對應SystemConfigtype=MeetType顯示 namevalue存此欄位0：尚未開始1：正常舉行2：停辦

               .ProjectTo<MinistryMeetingView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
