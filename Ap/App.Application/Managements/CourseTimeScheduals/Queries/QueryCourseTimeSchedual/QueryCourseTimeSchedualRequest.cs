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
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Queries.QueryCourseTimeSchedule
{
    /// <summary>
    /// 分頁查詢 CourseTimeSchedule
    /// </summary>
    public class QueryCourseTimeScheduleRequest
        : PageableQuery, IRequest<Page<CourseTimeScheduleView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long CourseId { get; set; }

        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }

        ///  <summary>
        ///附件類別對應type=ClassDay顯示 namevalue存此欄位1：一2：二….
        /// </summary>
        public string ClassDay { get; set; }

        ///  <summary>
        ///開始時間
        /// </summary>
        public string ClassTimeS { get; set; }

        ///  <summary>
        ///結束時間
        /// </summary>
        public string ClassTimeE { get; set; }

        ///  <summary>
        ///地點
        /// </summary>
        public string Place { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseTimeSchedule
    /// </summary>
    public class QueryCourseTimeScheduleRequestHandler
        : IRequestHandler<QueryCourseTimeScheduleRequest, Page<CourseTimeScheduleView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseTimeScheduleRequestHandler(
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
        public async Task<Page<CourseTimeScheduleView>> Handle(
            QueryCourseTimeScheduleRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseTimeSchedules
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)                                        //教會開課主檔
               .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)                      //Course.Id
               .WhereWhenNotEmpty(request.ScheduleNo?.ToString(), c => c.ScheduleNo == request.ScheduleNo) //代號/梯次
               .WhereWhenNotEmpty(request.ClassDay?.ToString(), c => c.ClassDay == request.ClassDay) //附件類別對應type=ClassDay顯示 namevalue存此欄位1：一2：二….
               .WhereWhenNotEmpty(request.ClassTimeS?.ToString(), c => c.ClassTimeS == request.ClassTimeS) //開始時間
               .WhereWhenNotEmpty(request.ClassTimeE?.ToString(), c => c.ClassTimeE == request.ClassTimeE) //結束時間
               .WhereWhenNotEmpty(request.Place?.ToString(), c => c.Place == request.Place) //地點
               .ProjectTo<CourseTimeScheduleView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
