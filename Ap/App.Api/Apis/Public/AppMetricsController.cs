using System;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace App.Api.Apis.Public
{
    /// <summary>
    /// </summary>
    [Route("api/pbl/[controller]")]
    
    public class AppMetricsController : ApiControllerBase
    {
        /// <summary>
        /// 取得 build commit hash
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [SkipApiLogAttribute]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [Route("version")]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public ApiResponse<string> GetAppVersionAsync([FromServices] IHostEnvironment environment)
        {
            var result = BuildVersion.Version;

            if (!string.Equals(environment.EnvironmentName, Environments.Production))
            {
                result = $"{result} ({environment.EnvironmentName})";
            }

            var res = new ApiResponse<string>()
            {
                Data = result
            };

            return res;
        }

        /// <summary>
        /// Ping
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [SkipApiLogAttribute]
        [Route("ping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [HttpGet]
        public ApiResponse<string> Ping(bool throwEx)
        {
            if (throwEx)
            {
                throw new Exception("Just Kidding" + DateTime.Now);
            }

            return new ApiResponse<string>()
            {
                Data = "pong"
            };
        }
    }
}
