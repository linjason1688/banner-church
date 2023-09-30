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
using App.Application.Managements.CoursePrices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.CoursePrices.Queries.FindCoursePrice
{
    /// <summary>
    /// 取得  CoursePrice 單筆明細
    /// </summary>

    public class FindCoursePriceRequest 
        : IRequest<CoursePriceView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCoursePriceRequestHandler 
        : IRequestHandler<FindCoursePriceRequest, CoursePriceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCoursePriceRequestHandler(
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
        public async Task<CoursePriceView> Handle(
            FindCoursePriceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .CoursePrices
               .Where(e => e.Id == request.Id)
               .ProjectTo<CoursePriceView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
