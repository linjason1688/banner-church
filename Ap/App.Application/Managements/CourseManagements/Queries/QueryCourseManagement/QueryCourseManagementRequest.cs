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
using App.Application.Managements.CourseManagements.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagements.Queries.QueryCourseManagement
{
    /// <summary>
    /// 分頁查詢 CourseManagement
    /// </summary>

    public class QueryCourseManagementRequest 
        : PageableQuery, IRequest<Page<CourseManagementView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagementType.Id
        /// </summary>
        public long? CourseManagementTypeId { get; set; }

        ///  <summary>
        ///堂點Id Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }

        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }

        ///  <summary>
        ///課程作業繳交日期
        /// </summary>
        public DateTime HomeworkDate { get; set; }

        ///  <summary>
        ///課程標題
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string Description { get; set; }
        ///  <summary>
        ///課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
        /// </summary>
        public string CourseManagementStatus { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagement
    /// </summary>
    public class QueryCourseManagementRequestHandler 
        : IRequestHandler<QueryCourseManagementRequest, Page<CourseManagementView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementRequestHandler(
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
        public async Task<Page<CourseManagementView>> Handle(
            QueryCourseManagementRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagements
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//事工團職分明細主檔id
                .WhereWhen(Convert.ToInt64(request.CourseManagementTypeId ) != 0, c => c.CourseManagementTypeId == request.CourseManagementTypeId )//課程類別CourseManagementType.Id
                .WhereWhenNotEmpty(request.Title, c => c.Title == request.Title)//課程標題
                .WhereWhenNotEmpty(request.Description, c => c.Description == request.Description)//課程內容描述
                .WhereWhenNotEmpty(request.CourseManagementStatus, c => c.CourseManagementStatus == request.CourseManagementStatus)//課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
                .WhereWhenNotEmpty(request.CourseManagementNo, c => c.CourseManagementNo == request.CourseManagementNo)//課程代碼

                .WhereWhenNotEmpty(request.HomeworkDate.ToString(), c => c.HomeworkDate == request.HomeworkDate)//課程作業繳交日期
               .WhereWhenNotEmpty(request.StatusCd, c => c.StatusCd == request.StatusCd)


               .ProjectTo<CourseManagementView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
