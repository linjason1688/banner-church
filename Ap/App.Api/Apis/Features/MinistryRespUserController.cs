using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MinistryRespUsers.Commands.DeleteMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Commands.CreateMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Commands.DeleteMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Commands.UpdateMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Dtos;
using App.Application.Managements.MinistryRespUsers.Queries.FetchAllMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Queries.FindMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Queries.QueryMinistryRespUser;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 事工團職份團員主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryRespUserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MinistryRespUserController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }


        /// <summary>
        /// 建立事工團職份團員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespUserView>> CreateMinistryRespUser([FromBody] CreateMinistryRespUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改事工團職份團員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespUserView>> PutMinistryRespUser([FromBody] UpdateMinistryRespUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢事工團職份團員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryRespUserView>>> FindMinistryRespUser(
            [FromQuery] QueryMinistryRespUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryRespUserView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢事工團職份團員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MinistryRespUserView>>> FetchMinistryRespUsers(
            [FromBody] FetchAllMinistryRespUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryRespUserView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 刪除事工團職份團員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespUserView>> DeleteMinistryRespUser([FromBody] DeleteMinistryRespUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespUserView>()
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
        public async Task<ApiResponse<int>> RemoveMinistryRespUser([FromRoute] DeleteMinistryRespUserCommand request)
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
        public async Task<ApiResponse<MinistryRespUserView>> GetMinistryRespUser([FromRoute] FindMinistryRespUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespUserView>()
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
        public async Task<ApiResponse<Page<MinistryRespUserView>>> QueryMinistryRespUsers(
            [FromBody] QueryMinistryRespUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryRespUserView>>()
            {
                Data = data
            };
        }
    }
}
