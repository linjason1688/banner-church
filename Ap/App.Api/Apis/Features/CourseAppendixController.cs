using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix;
using App.Application.Managements.CourseAppendixs.Commands.DeleteCourseAppendix;
using App.Application.Managements.CourseAppendixs.Commands.UpdateCourseAppendix;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Application.Managements.CourseAppendixs.Queries.QueryCourseAppendix;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseAppendixs.Queries.FindCourseAppendix;
using System.Diagnostics.Metrics;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Application.Managements.CourseAppendixs.Queries.FetchAllCourseAppendix;
using App.Application.Managements.CourseAppendixs.Commands.DeleteCourseAppendix;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程附件主檔
    /// </summary>
    [Route("api/[controller]")]
    //
    [Auth]
    public class CourseAppendixController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseAppendixController(
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
        /// 建立課程附件主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseAppendixView>> CreateCourseAppendix([FromBody] CreateCourseAppendixCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseAppendixView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程附件主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseAppendix")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseAppendixView>> PutCourseAppendix([FromBody] UpdateCourseAppendixCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseAppendixView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程附件主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseAppendixView>>> FindCourseAppendix([FromQuery] QueryCourseAppendixRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseAppendixView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢附件主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseAppendixView>>> FetchCourseAppendixs(
            [FromBody] FetchAllCourseAppendixRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseAppendixView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程附件主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseAppendixView>> DeleteCourseAppendix([FromBody] DeleteCourseAppendixCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseAppendixView>()
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
        public async Task<ApiResponse<int>> RemoveCourseAppendix([FromRoute] DeleteCourseAppendixCommand request)
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
        public async Task<ApiResponse<CourseAppendixView>> GetCourseAppendix([FromRoute] FindCourseAppendixRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseAppendixView>()
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
        public async Task<ApiResponse<Page<CourseAppendixView>>> QueryCourseAppendixs(
            [FromBody] QueryCourseAppendixRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseAppendixView>>()
            {
                Data = data
            };
        }


    }
}

