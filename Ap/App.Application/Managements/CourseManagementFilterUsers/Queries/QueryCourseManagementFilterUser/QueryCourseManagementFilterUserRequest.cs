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
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Queries.QueryCourseManagementFilterUser
{
    /// <summary>
    /// 分頁查詢 CourseManagementFilterUser
    /// </summary>

    public class QueryCourseManagementFilterUserRequest 
        : PageableQuery, IRequest<Page<CourseManagementFilterUserView>>
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
        ///     UserId.Id
        /// </summary>
        public long UserId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 CourseManagementFilterUser
    /// </summary>
    public class QueryCourseManagementFilterUserRequestHandler 
        : IRequestHandler<QueryCourseManagementFilterUserRequest, Page<CourseManagementFilterUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseManagementFilterUserRequestHandler(
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
        public async Task<Page<CourseManagementFilterUserView>> Handle(
            QueryCourseManagementFilterUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterUsers
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)
               .WhereWhen(Convert.ToInt64(request.CourseManagementFilterId ) != 0, c => c.CourseManagementFilterId == request.CourseManagementFilterId )
               .WhereWhen(Convert.ToInt64(request.UserId) != 0, c => c.UserId == request.UserId)
               .ProjectTo<CourseManagementFilterUserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
