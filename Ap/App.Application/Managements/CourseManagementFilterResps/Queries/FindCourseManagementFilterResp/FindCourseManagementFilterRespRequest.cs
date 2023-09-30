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
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Queries.FindCourseManagementFilterResp
{
    /// <summary>
    /// 取得  CourseManagementFilterResp 單筆明細
    /// </summary>

    public class FindCourseManagementFilterRespRequest 
        : IRequest<CourseManagementFilterRespView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterRespRequestHandler 
        : IRequestHandler<FindCourseManagementFilterRespRequest, CourseManagementFilterRespView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCourseManagementFilterRespRequestHandler(
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
        public async Task<CourseManagementFilterRespView> Handle(
            FindCourseManagementFilterRespRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementFilterResps
               .Where(e => e.Id == request.Id)
               .ProjectTo<CourseManagementFilterRespView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
