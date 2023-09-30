using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.UserSocieties.Commands.CreateUserSociety;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.Users.Dtos;
using App.Application.Managements.Users.Queries.FindUser;
using App.Application.Managements.Users.Queries.QueryUser;
using App.Application.Managements.UserSocieties.Queries.FindUserSociety;
using App.Application.Managements.UserSocieties.Queries.FetchAllUserSociety;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 使用者工會/社團檔主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class UserSocietyController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public UserSocietyController(
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
        /// 建立使用者工會/社團檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("UserSociety")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserSocietyView>> CreateUserSociety([FromBody] CreateUserSocietyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserSocietyView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改社團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createUserSociety")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserSocietyView>> PutUserSociety([FromBody] UpdateUserSocietyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserSocietyView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢社團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createUserSociety")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserSocietyView>>> FindUserSociety([FromQuery] QueryUserSocietyRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<UserSocietyView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢社團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserSocietyView>>> FetchUserSocietys(
            [FromBody] FetchAllUserSocietyRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserSocietyView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除社團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createUserSociety")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserSocietyView>> DeleteUserSociety([FromBody] DeleteUserSocietyCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<UserSocietyView>()
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
        public async Task<ApiResponse<int>> RemoveUserSociety([FromRoute] DeleteUserSocietyCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }


        /// <summary>
        /// 以 Id 查詢社團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserSocietyView>> GetUserSociety([FromRoute] FindUserSocietyRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserSocietyView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢社團列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserSocietyView>>> QueryUserSocietys(
            [FromBody] QueryUserSocietyRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserSocietyView>>()
            {
                Data = data
            };
        }




    }
}

