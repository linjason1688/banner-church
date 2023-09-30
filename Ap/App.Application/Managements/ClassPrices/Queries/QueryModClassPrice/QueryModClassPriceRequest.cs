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
using App.Application.Managements.ClassPrices.ModClassPrices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Queries.QueryModClassPrice
{
    /// <summary>
    /// 分頁查詢 ModClassPrice
    /// </summary>

    public class QueryModClassPriceRequest 
        : PageableQuery, IRequest<Page<ModClassPriceView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 ModClassPrice
    /// </summary>
    public class QueryModClassPriceRequestHandler 
        : IRequestHandler<QueryModClassPriceRequest, Page<ModClassPriceView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryModClassPriceRequestHandler(
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
        public async Task<Page<ModClassPriceView>> Handle(
            QueryModClassPriceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModClassPrices
               .ProjectTo<ModClassPriceView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
