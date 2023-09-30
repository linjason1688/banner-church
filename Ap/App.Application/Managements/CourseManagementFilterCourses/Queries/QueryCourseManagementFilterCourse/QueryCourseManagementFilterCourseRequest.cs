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
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Queries.QueryCourseManagementFilterCourse
{
    /// <summary>
    /// 分頁查詢 CourseManagementFilterCourse
    /// </summary>

    public class QueryCourseManagementFilterCourseRequest 
        : PageableQuery, IRequest<Page<CourseManagementFilterCourseView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///課程樣板過濾CourseManagementFilter.Id
        /// </summary>
        public long CourseManagementFilterId { get; set; }

        ///  <summary>
        ///     CourseManagement.Id
        /// </summary>
        public long CourseManagementId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagementFilterCourse
    /// </summary>
    public class QueryCourseManagementFilterCourseRequestHandler 
        : IRequestHandler<QueryCourseManagementFilterCourseRequest, Page<CourseManagementFilterCourseView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementFilterCourseRequestHandler(
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
        public async Task<Page<CourseManagementFilterCourseView>> Handle(
            QueryCourseManagementFilterCourseRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterCourses
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
 

                .WhereWhen(Convert.ToInt64(request.CourseManagementFilterId) > 0, c => c.CourseManagementFilterId == request.CourseManagementFilterId)//課程類別CourseManagement.Id
                .WhereWhen(Convert.ToInt64(request.CourseManagementId) > 0, c => c.CourseManagementId == request.CourseManagementId)//課程類別CourseManagement.Id


               .ProjectTo<CourseManagementFilterCourseView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
