#region

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Authenticate.Dtos;
using App.Application.Authenticate.Queries.FetchMyPrivilege;
using App.Application.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

#endregion

namespace App.Api.Apis.Public
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pbl/[controller]")]
    public class AuthController : ApiControllerBase
    {
        /// <summary>
        /// 取得權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Auth]
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("me/privileges")]
        [HttpPost]
        public async Task<ApiResponse<List<PrivilegeNode>>> FetchMyPrivilegesAsync(
            [FromBody] FetchMyPrivilegeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<List<PrivilegeNode>>()
            {
                Data = data
            };

            return res;
        }
    }
}
