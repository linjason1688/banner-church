#region

using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Core.Logs.Dtos;
using App.Application.Core.Logs.Queries.QueryApiAuditLog;
using App.Application.Core.Logs.Queries.QueryExceptionLog;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

#endregion

namespace App.Api.Apis.Management
{
    /// <summary>
    /// App Log 管理
    /// </summary>
    [Route("api/management/[controller]")]
    [Auth]
    public class AppLogMgrController : ApiControllerBase
    {
        /// <summary>
        /// App Api Log 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [SkipApiLog]
        [Route("apiLog/query")]
        [HttpPost]
        public async Task<ApiResponse<Page<ApiAuditLogView>>> QueryApiLogAsync(
            [FromBody] QueryApiAuditLogRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Page<ApiAuditLogView>>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// App Exception Log 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("exception/query")]
        [HttpPost]
        public async Task<ApiResponse<Page<ExceptionLogView>>> QueryExceptionLogAsync(
            [FromBody] QueryExceptionLogRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Page<ExceptionLogView>>()
            {
                Data = data
            };

            return res;
        }
    }
}
