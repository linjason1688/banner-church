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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Core.Logs.Queries.QueryApiAuditLog
{
    /// <summary>
    /// </summary>
    public class QueryApiAuditLogRequest : PageableQuery, IRequest<Page<ApiAuditLogView>>, ICreateAtRangeQuery
    {
        /// <summary>
        /// 交易處理 id
        /// </summary>
        public Guid? HandledId { get; set; }

        /// <summary>
        /// 帳號(員工編號)
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 來源 ip
        /// </summary>
        public string SourceIp { get; set; }

        /// <summary>
        /// 請求網址路徑
        /// </summary>
        public string RequestPath { get; set; }

        /// <summary>
        /// HTTP 回應碼
        /// </summary>
        public int? ResponseStatusCode { get; set; }

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
    public class QueryApiAuditLogRequestHandler : IRequestHandler<QueryApiAuditLogRequest, Page<ApiAuditLogView>>
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
        public QueryApiAuditLogRequestHandler(
            ILogger<QueryApiAuditLogRequestHandler> logger,
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
        public async Task<Page<ApiAuditLogView>> Handle(
            QueryApiAuditLogRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ApiAuditLog
               .WhereWhen(request.HandledId.HasValue, e => e.HandledId == request.HandledId)
               .WhereWhen(!string.IsNullOrEmpty(request.Account), e => e.Account.Equals(request.Account))
               .WhereWhen(!string.IsNullOrEmpty(request.SourceIp), e => e.SourceIp.Equals(request.SourceIp))
               .WhereWhen(
                    !string.IsNullOrEmpty(request.RequestPath),
                    e => EF.Functions.Like(e.RequestPath, $"%{request.RequestPath}%")
                )
               .WhereWhen(request.ResponseStatusCode.HasValue, e => e.ResponseStatusCode == request.ResponseStatusCode)
               .ApplyCreateAtRangeConstraint(request)
               .ProjectTo<ApiAuditLogView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
