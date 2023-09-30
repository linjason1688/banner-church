using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MinistryMeetings.Commands.DeleteMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Commands.CreateMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Commands.DeleteMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Commands.UpdateMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Dtos;
using App.Application.Managements.MinistryMeetings.Queries.FindMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Queries.QueryMinistryMeeting;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

//#CreateAPI
namespace App.Api.Apis.Features
{
    /// <summary>
    /// 會議主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryMeetingController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MinistryMeetingController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }


        /// <summary>
        /// 建立會議
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]

        //[Route("MinistryMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingView>> CreateMinistryMeeting(
            [FromBody] CreateMinistryMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryMeetingView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改會議
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]

        //[Route("createMinistryMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingView>> PutMinistryMeeting(
            [FromBody] UpdateMinistryMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryMeetingView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢會議
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]

        //[Route("createMinistryMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryMeetingView>>> FindMinistryMeeting(
            [FromQuery] QueryMinistryMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryMeetingView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除會議
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]

        //[Route("createMinistryMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingView>> DeleteMinistryMeeting(
            [FromBody] DeleteMinistryMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryMeetingView>()
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
        public async Task<ApiResponse<int>> RemoveMinistryMeeting([FromRoute] DeleteMinistryMeetingCommand request)
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
        public async Task<ApiResponse<MinistryMeetingView>> GetMinistryMeetingOfId(
            [FromRoute] FindMinistryMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryMeetingView>()
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
        public async Task<ApiResponse<Page<MinistryMeetingView>>> QueryMinistryMeetings(
            [FromBody] QueryMinistryMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryMeetingView>>()
            {
                Data = data
            };
        }
    }
}
