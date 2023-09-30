using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Application.Managements.PastoralMeetings.Queries.FetchAllPastoralMeeting;
using App.Application.Managements.PastoralMeetings.Commands.CreatePastoralMeeting;
using App.Application.Managements.PastoralMeetings.Commands.DeletePastoralMeeting;
using App.Application.Managements.PastoralMeetings.Commands.UpdatePastoralMeeting;
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Application.Managements.PastoralMeetings.Queries.FindPastoralMeeting;
using App.Application.Managements.PastoralMeetings.Queries.QueryPastoralMeeting;
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
    public class PastoralMeetingController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public PastoralMeetingController(
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

        //[Route("PastoralMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingView>> CreatePastoralMeeting(
            [FromBody] CreatePastoralMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralMeetingView>()
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

        //[Route("createPastoralMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingView>> PutPastoralMeeting(
            [FromBody] UpdatePastoralMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralMeetingView>()
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

        //[Route("createPastoralMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<PastoralMeetingView>>> FindPastoralMeeting(
            [FromQuery] QueryPastoralMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<PastoralMeetingView>>()
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
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<PastoralMeetingView>>> FetchPastoralMeetings(
            [FromBody] FetchAllPastoralMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PastoralMeetingView>>()
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

        //[Route("createPastoralMeeting")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingView>> DeletePastoralMeeting(
            [FromBody] DeletePastoralMeetingCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralMeetingView>()
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
        public async Task<ApiResponse<int>> RemovePastoralMeeting([FromRoute] DeletePastoralMeetingCommand request)
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
        public async Task<ApiResponse<PastoralMeetingView>> GetPastoralMeetingOfId(
            [FromRoute] FindPastoralMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralMeetingView>()
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
        public async Task<ApiResponse<Page<PastoralMeetingView>>> QueryPastoralMeetings(
            [FromBody] QueryPastoralMeetingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<PastoralMeetingView>>()
            {
                Data = data
            };
        }
    }
}
