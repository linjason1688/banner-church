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
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Queries.QueryCourseManagementFilterPastoral
{
    /// <summary>
    /// 分頁查詢 CourseManagementFilterPastoral
    /// </summary>

    public class QueryCourseManagementFilterPastoralRequest 
        : PageableQuery, IRequest<Page<CourseManagementFilterPastoralView>>
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
        ///     Pastoral.Id
        /// </summary>
        public long PastoralId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagementFilterPastoral
    /// </summary>
    public class QueryCourseManagementFilterPastoralRequestHandler 
        : IRequestHandler<QueryCourseManagementFilterPastoralRequest, Page<CourseManagementFilterPastoralView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementFilterPastoralRequestHandler(
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
        public async Task<Page<CourseManagementFilterPastoralView>> Handle(
            QueryCourseManagementFilterPastoralRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterPastorals
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
              .WhereWhen(Convert.ToInt64(request.CourseManagementFilterId) > 0, c => c.CourseManagementFilterId == request.CourseManagementFilterId)//課程類別CourseManagement.Id
               .WhereWhen(Convert.ToInt64(request.PastoralId) != 0, c => c.PastoralId == request.PastoralId)
               .ProjectTo<CourseManagementFilterPastoralView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
