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
using App.Application.Managements.VwMemberSummaries.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Queries.QueryVwMemberSummary
{
    /// <summary>
    /// 分頁查詢 VwMemberSummary
    /// </summary>

    public class QueryVwMemberSummaryRequest 
        : PageableQuery, IRequest<Page<VwMemberSummaryView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 VwMemberSummary
    /// </summary>
    public class QueryVwMemberSummaryRequestHandler 
        : IRequestHandler<QueryVwMemberSummaryRequest, Page<VwMemberSummaryView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryVwMemberSummaryRequestHandler(
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
        public async Task<Page<VwMemberSummaryView>> Handle(
            QueryVwMemberSummaryRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberSummaries
               .ProjectTo<VwMemberSummaryView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
