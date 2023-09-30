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
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Queries.QueryCourseTimeScheduleTeacher
{
    /// <summary>
    /// 分頁查詢 CourseTimeScheduleTeacher
    /// </summary>

    public class QueryCourseTimeScheduleTeacherRequest 
        : PageableQuery, IRequest<Page<CourseTimeScheduleTeacherView>>
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
        ///  <summary>
        ///Teacher.Id
        /// </summary>
        public long TeacherId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseTimeScheduleTeacher
    /// </summary>
    public class QueryCourseTimeScheduleTeacherRequestHandler 
        : IRequestHandler<QueryCourseTimeScheduleTeacherRequest, Page<CourseTimeScheduleTeacherView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseTimeScheduleTeacherRequestHandler(
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
        public async Task<Page<CourseTimeScheduleTeacherView>> Handle(
            QueryCourseTimeScheduleTeacherRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseTimeScheduleTeachers
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//教會開課主檔
                .WhereWhen(Convert.ToInt64(request.TeacherId ) != 0, c => c.TeacherId == request.TeacherId )//教會開課教師Id
                .WhereWhen(Convert.ToInt64(request.CourseTimeScheduleId ) != 0, c => c.CourseTimeScheduleId == request.CourseTimeScheduleId )//課程時段CourseTimeSchedule.Id
                .WhereWhenNotEmpty(request.ScheduleNo?.ToString(), c => c.ScheduleNo == request.ScheduleNo)//代號/梯次

               .ProjectTo<CourseTimeScheduleTeacherView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
