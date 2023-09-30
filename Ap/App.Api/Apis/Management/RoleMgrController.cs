#region

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.Roles.Commands.CreateRole;
using App.Application.Managements.Roles.Commands.DeleteRole;
using App.Application.Managements.Roles.Commands.UpdateRole;
using App.Application.Managements.Roles.Dtos;
using App.Application.Managements.Roles.Queries.FetchAllRole;
using App.Application.Managements.Roles.Queries.FindRole;
using App.Application.Managements.Roles.Queries.QueryRole;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

#endregion

namespace App.Api.Apis.Management
{
    /// <summary>
    /// Role 管理
    /// </summary>
    [Route("api/management/[controller]")]
    [Auth]
    public class RoleMgrController : ApiControllerBase
    {
        

        /// <summary>
        /// TOPIC查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("query")]
        [HttpPost]
        public async Task<ApiResponse<Page<RoleView>>> QueryAsync([FromBody] QueryRoleRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Page<RoleView>>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// TOPIC全部列表
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("fetchAll")]
        [HttpPost]
        public async Task<ApiResponse<IEnumerable<RoleView>>> FetchAllAsync(
            [FromBody] FetchAllRoleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<IEnumerable<RoleView>>()
            {
                Data = data
            };

            return res;
        }


        /// <summary>
        /// TOPIC詳細資訊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("findOne")]
        [HttpPost]
        public async Task<ApiResponse<RoleView>> FindOneAsync([FromBody] FindRoleRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<RoleView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 建立TOPIC
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("create")]
        [HttpPost]
        public async Task<ApiResponse<RoleView>> CreateAsync([FromBody] CreateRoleCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<RoleView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 更新 TOPIC
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("update")]
        [HttpPatch]
        public async Task<ApiResponse<RoleView>> UpdateAsync([FromBody] UpdateRoleCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<RoleView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 刪除 TOPIC
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("remove")]
        [HttpDelete]
        public async Task<ApiResponse<int>> RemoveAsync([FromBody] DeleteRoleCommand request)
        {
            await this.Mediator.Send(request);

            var res = new ApiResponse<int>();

            return res;
        }
    }
}

