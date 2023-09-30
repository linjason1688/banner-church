using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Managements.PastoralMeetingUsers.Commands.DeletePastoralMeetingUser;
//using App.Application.Features.CreatePastoralMeetingUser;
//using App.Application.Features.UPastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Commands;
using App.Application.Managements.PastoralMeetingUsers.Commands.CreatePastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Commands.DeletePastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Commands.UpdatePastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Dtos;
using App.Application.Managements.PastoralMeetingUsers.Queries.FetchAllPastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Queries.FindPastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Queries.QueryPastoralMeetingUser;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

//#CreateAPI
namespace App.Api.Apis.Features
{
    /// <summary>
    /// 會議簽到主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class PastoralMeetingUserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public PastoralMeetingUserController(
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
        //[Route("PastoralMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingUserView>> CreatePastoralMeetingUser([FromBody] CreatePastoralMeetingUserCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<PastoralMeetingUserView>()
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
        //[Route("createPastoralMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingUserView>> PutPastoralMeetingUser([FromBody] UpdatePastoralMeetingUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PastoralMeetingUserView>()
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
        //[Route("createPastoralMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<PastoralMeetingUserView>>> FindPastoralMeetingUser([FromQuery] QueryPastoralMeetingUserRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<PastoralMeetingUserView>>()
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
        public async Task<ApiResponse<List<PastoralMeetingUserView>>> FetchPastoralMeetingUsers(
            [FromBody] FetchAllPastoralMeetingUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PastoralMeetingUserView>>()
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
        //[Route("createPastoralMeetingUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralMeetingUserView>> DeletePastoralMeetingUser([FromBody] DeletePastoralMeetingUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PastoralMeetingUserView>()
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
        public async Task<ApiResponse<int>> RemovePastoralMeetingUser([FromRoute] DeletePastoralMeetingUserCommand request)
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
        public async Task<ApiResponse<PastoralMeetingUserView>> GetPastoralMeetingUser([FromRoute] FindPastoralMeetingUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralMeetingUserView>()
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
        public async Task<ApiResponse<Page<PastoralMeetingUserView>>> QueryPastoralMeetingUsers(
            [FromBody] QueryPastoralMeetingUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<PastoralMeetingUserView>>()
            {
                Data = data
            };
        }




    }
}
