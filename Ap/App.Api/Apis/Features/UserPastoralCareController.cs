using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.UserPastoralCares.Commands.CreateUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Commands.DeleteUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Commands.UpdateUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Dtos;
using App.Application.Managements.UserPastoralCares.Queries.QueryUserPastoralCare;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.UserPastoralCares.Queries.FindUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Queries.FetchAllUserPastoralCare;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 使用者牧養歷程檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class UserPastoralCareController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public UserPastoralCareController(
            VerificationCodeService verificationCodeService,
            IAppDbContext appDbContext,
            IMapper mapper
        )
        {
            this.verificationCodeService = verificationCodeService;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }


        /// <summary>
        /// 建立使用者牧養歷程檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("UserPastoralCare")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserPastoralCareView>> CreateUserPastoralCare([FromBody] CreateUserPastoralCareCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserPastoralCareView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改使用者牧養歷程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createUserPastoralCare")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserPastoralCareView>> PutUserPastoralCare([FromBody] UpdateUserPastoralCareCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserPastoralCareView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢使用者牧養歷程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createUserPastoralCare")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserPastoralCareView>>> FindUserPastoralCare([FromQuery] QueryUserPastoralCareRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<UserPastoralCareView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢使用者牧養歷程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserPastoralCareView>>> FetchUserPastoralCares(
            [FromBody] FetchAllUserPastoralCareRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserPastoralCareView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除使用者牧養歷程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createUserPastoralCare")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserPastoralCareView>> DeleteUserPastoralCare([FromBody] DeleteUserPastoralCareCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<UserPastoralCareView>()
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
        public async Task<ApiResponse<int>> RemoveUserPastoralCare([FromRoute] DeleteUserPastoralCareCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }


        /// <summary>
        /// 以 Id 查詢會員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserPastoralCareView>> GetUserPastoralCare([FromRoute] FindUserPastoralCareRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserPastoralCareView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢會員列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserPastoralCareView>>> QueryUserPastoralCares(
            [FromBody] QueryUserPastoralCareRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserPastoralCareView>>()
            {
                Data = data
            };
        }




    }
}

