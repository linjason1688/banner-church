using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Features.ChildSignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 為12歲以下註冊
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    [Auth]
    public class ChildController : ApiControllerBase
    {
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = false)]
        [HttpPost]
        [Route("signup")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ChildSignUpCommandResponse>> ChildSignUp([FromBody] ChildSignUpCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ChildSignUpCommandResponse>()
            {
                Data = data
            };
        }
    }
}
