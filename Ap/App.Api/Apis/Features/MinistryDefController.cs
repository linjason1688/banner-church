using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MinistryDefs.Dtos;
using App.Application.Managements.MinistryDefs.Queries.FetchAllMinistryDef;
using App.Application.Managements.MinistryDefs.Commands.CreateMinistryDef;
using App.Application.Managements.MinistryDefs.Commands.DeleteMinistryDef;
using App.Application.Managements.MinistryDefs.Commands.UpdateMinistryDef;

using App.Application.Managements.MinistryDefs.Queries.FindMinistryDef;
using App.Application.Managements.MinistryDefs.Queries.QueryMinistryDef;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;
using App.Application.Managements.MinistryDefs.Commands.DeleteMinistryDef;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 事工團類別主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryDefController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MinistryDefController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }


        /// <summary>
        /// 建立事工團類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryDefView>> CreateMinistryDef([FromBody] CreateMinistryDefCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryDefView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改事工團類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryDefView>> PutMinistryDef([FromBody] UpdateMinistryDefCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryDefView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢事工團類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryDefView>>> FindMinistryDef(
            [FromQuery] QueryMinistryDefRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryDefView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢事工團類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MinistryDefView>>> FetchMinistryDefs(
            [FromBody] FetchAllMinistryDefRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryDefView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除事工團類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryDefView>> DeleteMinistryDef([FromBody] DeleteMinistryDefCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryDefView>()
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
        public async Task<ApiResponse<int>> RemoveMinistryDef([FromRoute] DeleteMinistryDefCommand request)
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
        public async Task<ApiResponse<MinistryDefView>> GetMinistryDef([FromRoute] FindMinistryDefRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryDefView>()
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
        public async Task<ApiResponse<Page<MinistryDefView>>> QueryMinistryDefs(
            [FromBody] QueryMinistryDefRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryDefView>>()
            {
                Data = data
            };
        }
    }
}
