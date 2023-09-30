#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
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
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Queries.FindCourseManagementFilterCourse
{
    /// <summary>
    /// 取得  CourseManagementFilterCourse 單筆明細
    /// </summary>

    public class FindCourseManagementFilterCourseRequest 
        : IRequest<CourseManagementFilterCourseView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterCourseRequestHandler 
        : IRequestHandler<FindCourseManagementFilterCourseRequest, CourseManagementFilterCourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCourseManagementFilterCourseRequestHandler(
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
        public async Task<CourseManagementFilterCourseView> Handle(
            FindCourseManagementFilterCourseRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterCourses
               .Where(e => e.Id == request.Id)
               .ProjectTo<CourseManagementFilterCourseView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
