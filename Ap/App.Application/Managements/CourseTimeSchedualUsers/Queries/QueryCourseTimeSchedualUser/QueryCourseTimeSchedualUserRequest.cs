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
using App.Application.Managements.CourseTimeScheduleUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Queries.QueryCourseTimeScheduleUser
{
    /// <summary>
    /// 分頁查詢 CourseTimeScheduleUser
    /// </summary>

    public class QueryCourseTimeScheduleUserRequest 
        : PageableQuery, IRequest<Page<CourseTimeScheduleUserView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///課程時段CourseTimeSchedule.Id
        /// </summary>
        public long CourseTimeScheduleId { get; set; }

        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }


        /// <summary>
        /// 出席狀態
        /// </summary>
        public string AttendanceType { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseTimeScheduleUser
    /// </summary>
    public class QueryCourseTimeScheduleUserRequestHandler 
        : IRequestHandler<QueryCourseTimeScheduleUserRequest, Page<CourseTimeScheduleUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseTimeScheduleUserRequestHandler(
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
        public async Task<Page<CourseTimeScheduleUserView>> Handle(
            QueryCourseTimeScheduleUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseTimeScheduleUsers 
               .WhereWhen(Convert.ToInt64(request.UserId) != 0, c => c.UserId == request.UserId)//教會上課學生Id                                                                                                
               .ProjectTo<CourseTimeScheduleUserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
