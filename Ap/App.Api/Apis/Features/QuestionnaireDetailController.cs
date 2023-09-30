using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.QuestionnaireDetails.Commands.CreateQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Commands.DeleteQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Commands.UpdateQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Dtos;
using App.Application.Managements.QuestionnaireDetails.Queries.QueryQuestionnaireDetail;

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
using App.Application.Managements.QuestionnaireDetails.Queries.FindQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Queries.FetchAllQuestionnaireDetail;
using App.Application.Managements.Questionnaires.Commands.DeleteQuestionnaire;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 問卷明細主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class QuestionnaireDetailController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public QuestionnaireDetailController(
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
        /// 建立問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("QuestionnaireDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireDetailView>> CreateQuestionnaireDetail([FromBody] CreateQuestionnaireDetailCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<QuestionnaireDetailView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createQuestionnaireDetail")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireDetailView>> PutQuestionnaireDetail([FromBody] UpdateQuestionnaireDetailCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<QuestionnaireDetailView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createQuestionnaireDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<QuestionnaireDetailView>>> FindQuestionnaireDetail([FromQuery] QueryQuestionnaireDetailRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<QuestionnaireDetailView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<QuestionnaireDetailView>>> FetchQuestionnaireDetails(
            [FromBody] FetchAllQuestionnaireDetailRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<QuestionnaireDetailView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createQuestionnaireDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireDetailView>> DeleteQuestionnaireDetail([FromBody] DeleteQuestionnaireDetailCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<QuestionnaireDetailView>()
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
        public async Task<ApiResponse<int>> RemoveQuestionnaireDetail([FromRoute] DeleteQuestionnaireDetailCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }

        /// <summary>
        /// 以 Id 查詢問卷明細
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireDetailView>> GetQuestionnaireDetail([FromRoute] FindQuestionnaireDetailRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<QuestionnaireDetailView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢問卷明細列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<QuestionnaireDetailView>>> QueryQuestionnaireDetails(
            [FromBody] QueryQuestionnaireDetailRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<QuestionnaireDetailView>>()
            {
                Data = data
            };
        }




    }
}

