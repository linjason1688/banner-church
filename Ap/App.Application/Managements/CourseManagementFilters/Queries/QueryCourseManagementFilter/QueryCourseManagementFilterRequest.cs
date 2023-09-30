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
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Courses.Dtos;
using App.Domain.Entities.Features;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Queries.QueryCourseManagementFilter
{
    /// <summary>
    /// 分頁查詢 CourseManagementFilter
    /// </summary>

    public class QueryCourseManagementFilterRequest 
        : PageableQuery, IRequest<Page<CourseManagementFilterView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///課程樣板CourseManagement.Id
        /// </summary>
        public long CourseManagementId { get; set; }

        ///  <summary>
        ///      堂點Id Organization.Id
        /// </summary>
        public long OrganizationId { get; set; }

        ///  <summary>
        ///課程性別限制
        /// </summary>
        public string? CourseSex { get; set; }

        ///  <summary>
        ///年齡門檻上
        /// </summary>
        public int? AgeUp { get; set; }

        ///  <summary>
        ///年齡門檻下
        /// </summary>
        public int? AgeDown { get; set; }

        
    }

    /// <summary>
    ///  分頁查詢 CourseManagementFilter
    /// </summary>
    public class QueryCourseManagementFilterRequestHandler 
        : IRequestHandler<QueryCourseManagementFilterRequest, Page<CourseManagementFilterView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementFilterRequestHandler(
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
        public async Task<Page<CourseManagementFilterView>> Handle(
            QueryCourseManagementFilterRequest request,
            CancellationToken cancellationToken
        )
        {




            var main = this.appDbContext
               .CourseManagementFilters
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
               .WhereWhen(Convert.ToInt64(request.CourseManagementId) != 0, c => c.CourseManagementId == request.CourseManagementId)
               .WhereWhen(Convert.ToInt64(request.OrganizationId) != 0, c => c.OrganizationId == request.OrganizationId)

               .WhereWhenNotEmpty(request.CourseSex?.ToString(), c => c.CourseSex == request.CourseSex)
               .WhereWhenNotEmpty(request.AgeUp?.ToString(), c => c.AgeUp == request.AgeUp)
               .WhereWhenNotEmpty(request.AgeDown?.ToString(), c => c.AgeDown == request.AgeDown);


       
            var crmLst = this.appDbContext.CourseManagements
                 .Where(c => main.Select(c => c.CourseManagementId).Contains(c.Id));

            var result = from m in main
                         join sod in crmLst on m.CourseManagementId equals sod.Id into lst1
                         from sod in lst1.DefaultIfEmpty()
                         select new CourseManagementFilterView
                         {
                             Id = m.Id,
                             DateCreate = m.DateCreate,
                             CourseManagementId = m.CourseManagementId,
                             OrganizationId = m.OrganizationId,
                             CourseSex=m.CourseSex,
                             AgeUp=m.AgeUp,
                             AgeDown=m.AgeDown,
                             CourseManagementNo=sod!=null? sod.CourseManagementNo:null

                         };

            var fin = await result
                          .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                          .ToPageAsync(request);

          
            return fin;

        }
    }
}
