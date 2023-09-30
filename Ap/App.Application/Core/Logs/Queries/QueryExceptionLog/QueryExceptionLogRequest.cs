#region

using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Core.Logs.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Core.Logs.Queries.QueryExceptionLog
{
    /// <summary>
    /// </summary>
    public class QueryExceptionLogRequest : PageableQuery, IRequest<Page<ExceptionLogView>>, ICreateAtRangeQuery
    {
        /// <summary>
        /// HandledId (值同 apiLog HandledId)
        /// </summary>
        public Guid? HandledId { get; set; }

        /// <summary>
        /// 紀錄起始時間
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateAtStart { get; set; }

        /// <summary>
        /// 紀錄結束時間
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateAtEnd { get; set; }
    }

    /// <summary>
    /// </summary>
    public class QueryExceptionLogRequestHandler : IRequestHandler<QueryExceptionLogRequest, Page<ExceptionLogView>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="authService"></param>
        public QueryExceptionLogRequestHandler(
            ILogger<QueryExceptionLogRequestHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Page<ExceptionLogView>> Handle(
            QueryExceptionLogRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ExceptionLog
               .WhereWhen(request.HandledId.HasValue, e => e.HandledId == request.HandledId)
               .ApplyCreateAtRangeConstraint(request)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ProjectTo<ExceptionLogView>(this.mapper.ConfigurationProvider)
               .ToPageAsync(request);
        }
    }
}
