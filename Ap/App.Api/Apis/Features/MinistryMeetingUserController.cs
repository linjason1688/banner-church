using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.MinistryMeetingUsers.Dtos;
using App.Application.Managements.MinistryMeetingUsers.Queries.FetchAllMinistryMeetingUser;
//using App.Application.Features.CreateMinistryMeetingUser;
//using App.Application.Features.UMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Commands;
using App.Application.Managements.MinistryMeetingUsers.Commands.CreateMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Commands.DeleteMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Commands.UpdateMinistryMeetingUser;

using App.Application.Managements.MinistryMeetingUsers.Queries.FindMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Queries.QueryMinistryMeetingUser;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;
using App.Application.Managements.MinistryMeetingUsers.Commands.DeleteMinistryMeetingUser;

//#CreateAPI
namespace App.Api.Apis.Features
{
    /// <summary>
    /// 會議簽到主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryMeetingUserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public MinistryMeetingUserController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }

        
        /// <summary>
        /// 建立會議簽到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("MinistryMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingUserView>> CreateMinistryMeetingUser([FromBody] CreateMinistryMeetingUserCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<MinistryMeetingUserView>()
                {
                    Data = data
                };
           
            
            
        }

        /// <summary>
        /// 修改會議簽到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createMinistryMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingUserView>> PutMinistryMeetingUser([FromBody] UpdateMinistryMeetingUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<MinistryMeetingUserView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢會議簽到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createMinistryMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryMeetingUserView>>> FindMinistryMeetingUser([FromQuery] QueryMinistryMeetingUserRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<MinistryMeetingUserView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢會議簽到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MinistryMeetingUserView>>> FetchMinistryMeetingUsers(
            [FromBody] FetchAllMinistryMeetingUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryMeetingUserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除會議簽到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createMinistryMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryMeetingUserView>> DeleteMinistryMeetingUser([FromBody] DeleteMinistryMeetingUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<MinistryMeetingUserView>()
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
        public async Task<ApiResponse<int>> RemoveMinistryMeetingUser([FromRoute] DeleteMinistryMeetingUserCommand request)
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
        public async Task<ApiResponse<MinistryMeetingUserView>> GetMinistryMeetingUser([FromRoute] FindMinistryMeetingUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryMeetingUserView>()
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
        public async Task<ApiResponse<Page<MinistryMeetingUserView>>> QueryMinistryMeetingUsers(
            [FromBody] QueryMinistryMeetingUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryMeetingUserView>>()
            {
                Data = data
            };
        }




    }
}
