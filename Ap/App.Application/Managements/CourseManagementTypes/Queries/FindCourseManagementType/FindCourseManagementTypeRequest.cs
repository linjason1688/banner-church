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
using App.Application.Managements.CourseManagementTypes.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Queries.FindCourseManagementType
{
    /// <summary>
    /// 取得  CourseManagementType 單筆明細
    /// </summary>

    public class FindCourseManagementTypeRequest 
        : IRequest<CourseManagementTypeView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementTypeRequestHandler 
        : IRequestHandler<FindCourseManagementTypeRequest, CourseManagementTypeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCourseManagementTypeRequestHandler(
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
        public async Task<CourseManagementTypeView> Handle(
            FindCourseManagementTypeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CourseManagementTypes
               .Where(e => e.Id == request.Id)
               .ProjectTo<CourseManagementTypeView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
