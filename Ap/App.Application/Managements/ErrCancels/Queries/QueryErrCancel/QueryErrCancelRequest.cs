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
using App.Application.Managements.ErrCancels.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ErrCancels.Queries.QueryErrCancel
{
    /// <summary>
    /// 分頁查詢 ErrCancel
    /// </summary>

    public class QueryErrCancelRequest 
        : PageableQuery, IRequest<Page<ErrCancelView>>
    {
    
        public string Name { get; set; }
    }

    /// <summary>
    ///  分頁查詢 ErrCancel
    /// </summary>
    public class QueryErrCancelRequestHandler 
        : IRequestHandler<QueryErrCancelRequest, Page<ErrCancelView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryErrCancelRequestHandler(
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
        public async Task<Page<ErrCancelView>> Handle(
            QueryErrCancelRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ErrCancels
               .ProjectTo<ErrCancelView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
