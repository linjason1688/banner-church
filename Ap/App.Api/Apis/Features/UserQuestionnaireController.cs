using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.UserQuestionnaires.Commands.CreateUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Commands.DeleteUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Commands.UpdateUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Dtos;
using App.Application.Managements.UserQuestionnaires.Queries.QueryUserQuestionnaire;

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
using App.Application.Managements.UserQuestionnaires.Queries.FindUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Queries.FetchAllUserQuestionnaire;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 問卷主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class UserQuestionnaireController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public UserQuestionnaireController(
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
        /// 建立問卷主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("UserQuestionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserQuestionnaireView>> CreateUserQuestionnaire([FromBody] CreateUserQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserQuestionnaireView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createUserQuestionnaire")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserQuestionnaireView>> PutUserQuestionnaire([FromBody] UpdateUserQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserQuestionnaireView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createUserQuestionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserQuestionnaireView>>> FindUserQuestionnaire([FromQuery] QueryUserQuestionnaireRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<UserQuestionnaireView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserQuestionnaireView>>> FetchUserQuestionnaires(
            [FromBody] FetchAllUserQuestionnaireRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserQuestionnaireView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createUserQuestionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserQuestionnaireView>> DeleteUserQuestionnaire([FromBody] DeleteUserQuestionnaireCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<UserQuestionnaireView>()
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
        public async Task<ApiResponse<int>> RemoveUserQuestionnaire([FromRoute] DeleteUserQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }

        /// <summary>
        /// 以 Id 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserQuestionnaireView>> GetUserQuestionnaire([FromRoute] FindUserQuestionnaireRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserQuestionnaireView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢問卷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserQuestionnaireView>>> QueryUserQuestionnaires(
            [FromBody] QueryUserQuestionnaireRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserQuestionnaireView>>()
            {
                Data = data
            };
        }




    }
}

