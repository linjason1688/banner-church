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
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Queries.QueryCourseManagementFilterResp
{
    /// <summary>
    /// 分頁查詢 CourseManagementFilterResp
    /// </summary>

    public class QueryCourseManagementFilterRespRequest 
        : PageableQuery, IRequest<Page<CourseManagementFilterRespView>>
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
        ///     MinistryResp.Id
        /// </summary>
        public long MinistryRespId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagementFilterResp
    /// </summary>
    public class QueryCourseManagementFilterRespRequestHandler 
        : IRequestHandler<QueryCourseManagementFilterRespRequest, Page<CourseManagementFilterRespView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementFilterRespRequestHandler(
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
        public async Task<Page<CourseManagementFilterRespView>> Handle(
            QueryCourseManagementFilterRespRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterResps
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
               .WhereWhen(Convert.ToInt64(request.CourseManagementFilterId ) != 0, c => c.CourseManagementFilterId == request.CourseManagementFilterId )
               .WhereWhen(Convert.ToInt64(request.MinistryRespId ) != 0, c => c.MinistryRespId == request.MinistryRespId )
               .ProjectTo<CourseManagementFilterRespView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
