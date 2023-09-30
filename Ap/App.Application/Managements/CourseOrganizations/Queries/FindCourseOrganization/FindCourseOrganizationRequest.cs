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
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CourseOrganizations.Queries.FindCourseOrganization
{
    /// <summary>
    /// 取得  CourseOrganization 單筆明細
    /// </summary>

    public class FindCourseOrganizationRequest 
        : IRequest<CourseOrganizationView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCourseOrganizationRequestHandler 
        : IRequestHandler<FindCourseOrganizationRequest, CourseOrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCourseOrganizationRequestHandler(
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
        public async Task<CourseOrganizationView> Handle(
            FindCourseOrganizationRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseOrganizations
               .Where(e => e.Id == request.Id)
               .ProjectTo<CourseOrganizationView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
