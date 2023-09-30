using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.MessageInformationUsers.Commands.CreateMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Commands.DeleteMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Commands.UpdateMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Application.Managements.MessageInformationUsers.Queries.QueryMessageInformationUser;
using Yozian.Extension.Pagination;
using App.Application.Managements.MessageInformationUsers.Queries.FindMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Queries.FetchAllMessageInformationUser;
using System.Collections.Generic;
using App.Application.Managements.MessageInformationUsers.Commands.DeleteMessageInformationUser;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 訊息管理/通知
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MessageInformationUserController : ApiControllerBase
    {
        /// <summary>
        /// 建立訊息管理檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationUserView>> CreateMessageInformationUser(
            [FromBody] CreateMessageInformationUserCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationUserView>> PutMessageInformationUser(
            [FromBody] UpdateMessageInformationUserCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MessageInformationUserView>>> FindMessageInformationUser(
            [FromQuery] QueryMessageInformationUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MessageInformationUserView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MessageInformationUserView>>> FetchMessageInformationUsers(
            [FromBody] FetchAllMessageInformationUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MessageInformationUserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationUserView>> DeleteMessageInformationUser(
            [FromBody] DeleteMessageInformationUserCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationUserView>()
            {
                //Data = data
            };
        }
        /// <summary>
        /// 刪除主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<int>> RemoveMessageInformationUser([FromRoute] DeleteMessageInformationUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }
        /// <summary>
        /// 以 Id 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationUserView>> GetMessageInformationUserOfId(
            [FromRoute] FindMessageInformationUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationUserView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MessageInformationUserView>>> QueryMessageInformationUsers(
            [FromBody] QueryMessageInformationUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MessageInformationUserView>>()
            {
                Data = data
            };
        }
    }
}
