#region

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.Privileges.Commands.AuthRolePrivilege;
using App.Application.Managements.Privileges.Commands.CreatePrivilege;
using App.Application.Managements.Privileges.Commands.DeletePrivilege;
using App.Application.Managements.Privileges.Commands.UpdatePrivilege;
using App.Application.Managements.Privileges.Dtos;
using App.Application.Managements.Privileges.Queries.FetchAllPrivilege;
using App.Application.Managements.Privileges.Queries.FetchRolePrivilege;
using App.Application.Managements.Privileges.Queries.FindPrivilege;
using App.Application.Managements.Privileges.Queries.QueryPrivilege;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

#endregion

namespace App.Api.Apis.Management
{
    /// <summary>
    /// 權限 管理
    /// </summary>
    [Route("api/management/[controller]")]
    [Auth]
    public class PrivilegeMgrController : ApiControllerBase
    {
        /// <summary>
        /// 權限 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("query")]
        [HttpPost]
        public async Task<ApiResponse<Page<PrivilegeView>>> QueryAsync([FromBody] QueryPrivilegeRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Page<PrivilegeView>>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 權限 全部列表
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("fetchAll")]
        [HttpPost]
        public async Task<ApiResponse<IEnumerable<PrivilegeView>>> FetchAllAsync(
            [FromBody] FetchAllPrivilegeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<IEnumerable<PrivilegeView>>()
            {
                Data = data
            };

            return res;
        }


        /// <summary>
        /// 權限 詳細資訊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("findOne")]
        [HttpPost]
        public async Task<ApiResponse<PrivilegeView>> FindOneAsync([FromBody] FindPrivilegeRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<PrivilegeView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 建立權限 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("create")]
        [HttpPost]
        public async Task<ApiResponse<PrivilegeView>> CreateAsync([FromBody] CreatePrivilegeCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<PrivilegeView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 更新 權限 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("update")]
        [HttpPatch]
        public async Task<ApiResponse<PrivilegeView>> UpdateAsync([FromBody] UpdatePrivilegeCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<PrivilegeView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 刪除 權限 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("remove")]
        [HttpDelete]
        public async Task<ApiResponse<int>> RemoveAsync([FromBody] DeletePrivilegeCommand request)
        {
            await this.Mediator.Send(request);

            var res = new ApiResponse<int>();

            return res;
        }

        /// <summary>
        /// 取得角色權限 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("role/privileges")]
        [HttpPost]
        public async Task<ApiResponse<List<PrivilegeNodeView>>> FetchRolePrivilegeAsync(
            [FromBody] FetchRolePrivilegeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<List<PrivilegeNodeView>>()
            {
                Data = data
            };

            return res;
        }


        /// <summary>
        /// 更新角色權限 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("role/privileges/auth")]
        [HttpPatch]
        public async Task<ApiResponse<Unit>> AuthRolePrivilegeAsync([FromBody] AuthRolePrivilegeCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Unit>()
            {
                Data = data
            };

            return res;
        }
    }
}
