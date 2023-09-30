using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MeetingPoints.Dtos;
using App.Application.Managements.MeetingPoints.Queries.FetchAllMeetingPoint;
using App.Application.Managements.MeetingPoints.Commands.CreateMeetingPoint;
using App.Application.Managements.MeetingPoints.Commands.DeleteMeetingPoint;
using App.Application.Managements.MeetingPoints.Commands.UpdateMeetingPoint;

using App.Application.Managements.MeetingPoints.Queries.FindMeetingPoint;
using App.Application.Managements.MeetingPoints.Queries.QueryMeetingPoint;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;
using App.Application.Managements.MeetingPoints.Commands.DeleteMeetingPoint;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 聚會點主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MeetingPointController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MeetingPointController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }


        /// <summary>
        /// 建立聚會點
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MeetingPointView>> CreateMeetingPoint([FromBody] CreateMeetingPointCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MeetingPointView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改聚會點
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MeetingPointView>> PutMeetingPoint([FromBody] UpdateMeetingPointCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MeetingPointView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢聚會點
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MeetingPointView>>> FindMeetingPoint(
            [FromQuery] QueryMeetingPointRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MeetingPointView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢聚會點2 註冊使用 不用登入即可查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [AllowAnonymous]
        [Route("anonymous/fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MeetingPointView>>> FetchMeetingPoints2(
            [FromBody] FetchAllMeetingPointRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MeetingPointView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢聚會點
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MeetingPointView>>> FetchMeetingPoints(
            [FromBody] FetchAllMeetingPointRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MeetingPointView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除聚會點
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MeetingPointView>> DeleteMeetingPoint([FromBody] DeleteMeetingPointCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MeetingPointView>()
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
        public async Task<ApiResponse<int>> RemoveMeetingPoint([FromRoute] DeleteMeetingPointCommand request)
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
        public async Task<ApiResponse<MeetingPointView>> GetMeetingPoint([FromRoute] FindMeetingPointRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MeetingPointView>()
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
        public async Task<ApiResponse<Page<MeetingPointView>>> QueryMeetingPoints(
            [FromBody] QueryMeetingPointRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MeetingPointView>>()
            {
                Data = data
            };
        }
    }
}
