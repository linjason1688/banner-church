#region

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.Users.Commands.AssignUserRole;
using App.Application.Managements.Users.Commands.CreateUser;
using App.Application.Managements.Users.Commands.DeleteUser;
using App.Application.Managements.Users.Commands.UpdateUser;
using App.Application.Managements.Users.Dtos;
using App.Application.Managements.Users.Queries.FetchAllUser;
using App.Application.Managements.Users.Queries.FindUser;
using App.Application.Managements.Users.Queries.QueryUser;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

#endregion

namespace App.Api.Apis.Management
{
    /// <summary>
    /// User 管理
    /// </summary>
    [Route("api/management/[controller]")]
    [Auth]
    public class UserMgrController : ApiControllerBase
    {
        /// <summary>
        /// User 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("query")]
        [HttpPost]
        public async Task<ApiResponse<Page<UserView>>> QueryAsync([FromBody] QueryUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<Page<UserView>>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// User 全部列表
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody]
        [Route("fetchAll")]
        [HttpPost]
        public async Task<ApiResponse<IEnumerable<UserView>>> FetchAllAsync(
            [FromBody] FetchAllUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<IEnumerable<UserView>>()
            {
                Data = data
            };

            return res;
        }


        /// <summary>
        /// User 詳細資訊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("findOne")]
        [HttpPost]
        public async Task<ApiResponse<UserView>> FindOneAsync([FromBody] FindUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<UserView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 建立User 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("create")]
        [HttpPost]
        public async Task<ApiResponse<UserView>> CreateAsync([FromBody] CreateUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<UserView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 更新 User 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("update")]
        [HttpPatch]
        public async Task<ApiResponse<UserView>> UpdateAsync([FromBody] UpdateUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            var res = new ApiResponse<UserView>()
            {
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 刪除 User 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("remove")]
        [HttpDelete]
        public async Task<ApiResponse<int>> RemoveAsync([FromBody] DeleteUserCommand request)
        {
            await this.Mediator.Send(request);

            var res = new ApiResponse<int>();

            return res;
        }

        /// <summary>
        /// User 角色指派
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [Route("role/assign")]
        [HttpPost]
        public async Task<ApiResponse<int>> AssignRolesAsync([FromBody] AssignUserRoleCommand request)
        {
            await this.Mediator.Send(request);

            var res = new ApiResponse<int>();

            return res;
        }
    }
}
