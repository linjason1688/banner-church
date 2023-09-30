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
using App.Application.Managements.ClassDays.ModClassDays.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Queries.QueryModClassDay
{
    /// <summary>
    /// 分頁查詢 ModClassDay
    /// </summary>

    public class QueryModClassDayRequest 
        : PageableQuery, IRequest<Page<ModClassDayView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 ModClassDay
    /// </summary>
    public class QueryModClassDayRequestHandler 
        : IRequestHandler<QueryModClassDayRequest, Page<ModClassDayView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryModClassDayRequestHandler(
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
        public async Task<Page<ModClassDayView>> Handle(
            QueryModClassDayRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModClassDays
               .ProjectTo<ModClassDayView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
