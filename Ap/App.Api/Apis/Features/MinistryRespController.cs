using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MinistryResps.Dtos;
using App.Application.Managements.MinistryResps.Queries.FetchAllMinistryResp;
using App.Application.Managements.MinistryResps.Commands.CreateMinistryResp;
using App.Application.Managements.MinistryResps.Commands.DeleteMinistryResp;
using App.Application.Managements.MinistryResps.Commands.UpdateMinistryResp;

using App.Application.Managements.MinistryResps.Queries.FindMinistryResp;
using App.Application.Managements.MinistryResps.Queries.QueryMinistryResp;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;
using App.Application.Managements.MinistryResps.Commands.DeleteMinistryResp;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 事工團職份主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryRespController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MinistryRespController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }


        /// <summary>
        /// 建立事工團職份
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespView>> CreateMinistryResp([FromBody] CreateMinistryRespCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改事工團職份
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespView>> PutMinistryResp([FromBody] UpdateMinistryRespCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢事工團職份
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryRespView>>> FindMinistryResp(
            [FromQuery] QueryMinistryRespRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryRespView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢事工團職份
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MinistryRespView>>> FetchMinistryResps(
            [FromBody] FetchAllMinistryRespRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryRespView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除事工團職份
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryRespView>> DeleteMinistryResp([FromBody] DeleteMinistryRespCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespView>()
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
        public async Task<ApiResponse<int>> RemoveMinistryResp([FromRoute] DeleteMinistryRespCommand request)
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
        public async Task<ApiResponse<MinistryRespView>> GetMinistryResp([FromRoute] FindMinistryRespRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryRespView>()
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
        public async Task<ApiResponse<Page<MinistryRespView>>> QueryMinistryResps(
            [FromBody] QueryMinistryRespRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryRespView>>()
            {
                Data = data
            };
        }
    }
}
