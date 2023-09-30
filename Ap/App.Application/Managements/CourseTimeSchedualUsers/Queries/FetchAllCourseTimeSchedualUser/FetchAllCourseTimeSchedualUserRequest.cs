#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
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

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Queries.FetchAllCourseTimeScheduleUser
{
    /// <summary>
    /// 查詢  CourseTimeScheduleUser 所有資料
    /// </summary>

    public class FetchAllCourseTimeScheduleUserRequest 
        : IRequest<List<CourseTimeScheduleUserView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseTimeScheduleUserHandler 
        : IRequestHandler<FetchAllCourseTimeScheduleUserRequest, List<CourseTimeScheduleUserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllCourseTimeScheduleUserHandler(
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
        public async Task<List<CourseTimeScheduleUserView>> Handle(
            FetchAllCourseTimeScheduleUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseTimeScheduleUsers
               .ApplyLimitConstraint(request)
               .ProjectTo<CourseTimeScheduleUserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
