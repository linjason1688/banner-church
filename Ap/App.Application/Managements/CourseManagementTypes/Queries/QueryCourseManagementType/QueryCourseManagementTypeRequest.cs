#region

using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.CourseManagementTypes.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Queries.QueryCourseManagementType
{
    /// <summary>
    /// 分頁查詢 CourseManagementType
    /// </summary>
    public class QueryCourseManagementTypeRequest
        : PageableQuery, IRequest<Page<CourseManagementTypeView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 課程類別編號
        /// </summary>
        public string CourseManagementTypeNo { get; set; }

        /// <summary>
        /// 課程類別名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagementType
    /// </summary>
    public class QueryCourseManagementTypeRequestHandler
        : IRequestHandler<QueryCourseManagementTypeRequest, Page<CourseManagementTypeView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementTypeRequestHandler(
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
        public async Task<Page<CourseManagementTypeView>> Handle(
            QueryCourseManagementTypeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementTypes
               .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id) //id
               .WhereWhenNotEmpty(request.StatusCd, c => c.StatusCd == request.StatusCd)
               .WhereWhenNotEmpty(request.CourseManagementTypeNo,c => c.CourseManagementTypeNo == request.CourseManagementTypeNo) //課程類別編號
               .ProjectTo<CourseManagementTypeView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
