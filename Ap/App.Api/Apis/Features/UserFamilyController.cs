using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.UserFamilies.Commands.CreateUserFamily;
using App.Application.Managements.UserFamilies.Commands.DeleteUserFamily;
using App.Application.Managements.UserFamilies.Commands.UpdateUserFamily;
using App.Application.Managements.UserFamilies.Dtos;
using App.Application.Managements.UserFamilies.Queries.QueryUserFamily;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.UserFamilies.Queries.FindUserFamily;
using App.Application.Managements.UserFamilies.Queries.FetchAllUserFamily;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 使用者家庭連絡檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class UserFamilyController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public UserFamilyController(
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
        /// 建立使用者家庭連絡檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("UserFamily")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserFamilyView>> CreateUserFamily([FromBody] CreateUserFamilyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserFamilyView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改使用者家庭連絡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createUserFamily")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserFamilyView>> PutUserFamily([FromBody] UpdateUserFamilyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserFamilyView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢使用者家庭連絡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createUserFamily")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserFamilyView>>> FindUserFamily([FromQuery] QueryUserFamilyRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<UserFamilyView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢使用者家庭連絡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserFamilyView>>> FetchUserFamilies(
            [FromBody] FetchAllUserFamilyRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserFamilyView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除使用者家庭連絡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createUserFamily")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserFamilyView>> DeleteUserFamily([FromBody] DeleteUserFamilyCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<UserFamilyView>()
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
        public async Task<ApiResponse<int>> RemoveUserFamily([FromRoute] DeleteUserFamilyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }


        /// <summary>
        /// 以 Id 查詢家庭連絡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserFamilyView>> GetUserFamily([FromRoute] FindUserFamilyRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserFamilyView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢家庭連絡列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserFamilyView>>> QueryUserFamilies(
            [FromBody] QueryUserFamilyRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserFamilyView>>()
            {
                Data = data
            };
        }




    }
}

