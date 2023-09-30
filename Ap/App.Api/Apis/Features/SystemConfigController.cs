using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Features.FindConfig.Commands;
using App.Application.Features.FindConfig.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.SystemConfigs.Dtos;
using App.Application.Managements.SystemConfigs.Queries.FetchAllSystemConfig;
using App.Application.Managements.MinistryDefs.Dtos;
using App.Application.Managements.MinistryDefs.Queries.QueryMinistryDef;
using App.Application.Managements.SystemConfigs.Queries.QuerySystemConfig;
using Yozian.Extension.Pagination;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// SystemConfig 系統參數
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    //[Auth]
    public class SystemConfigController : ApiControllerBase
    {
        public SystemConfigController()
        {
        }

        /// <summary>
        /// 查詢系統參數
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("config")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<FindConfigResponse>> GetConfig(
            [FromQuery] FindConfigCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<FindConfigResponse>()
            {
                Data = data
            };
        }
       
     

      

        /// <summary>
        /// 會友所屬堂點清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("church/names")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<SystemConfigView>>> FindConfigOfChurch(
            [FromQuery] FetchAllSystemConfigRequest request
        )
        {
            request.Type = "ChurchNameList";
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<SystemConfigView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢所有的系統參數
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("configs")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<SystemConfigView>>> FindConfig(
            [FromQuery] FetchAllSystemConfigRequest request
        )
        {

            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<SystemConfigView>>()
            {
                Data = data
            };
        }
    }
}
