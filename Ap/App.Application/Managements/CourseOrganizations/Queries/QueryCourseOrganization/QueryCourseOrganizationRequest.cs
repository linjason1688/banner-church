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
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.CourseOrganizations.Queries.QueryCourseOrganization
{
    /// <summary>
    /// 分頁查詢 CourseOrganization
    /// </summary>

    public class QueryCourseOrganizationRequest 
        : PageableQuery, IRequest<Page<CourseOrganizationView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }

        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long OrganizationId { get; set; }


   
    }

    /// <summary>
    ///  分頁查詢 CourseOrganization
    /// </summary>
    public class QueryCourseOrganizationRequestHandler 
        : IRequestHandler<QueryCourseOrganizationRequest, Page<CourseOrganizationView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseOrganizationRequestHandler(
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
        public async Task<Page<CourseOrganizationView>> Handle(
            QueryCourseOrganizationRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseOrganizations
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//開課價格主檔
                .WhereWhen(Convert.ToInt64(request.CourseId) != 0, c => c.CourseId == request.CourseId)//課程類別Course.Id
                 .WhereWhen(Convert.ToInt64(request.OrganizationId) != 0, c => c.OrganizationId == request.OrganizationId)//課程類別Course.Id       
                 .ProjectTo<CourseOrganizationView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
