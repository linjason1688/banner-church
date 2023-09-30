using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementAppendixs.Commands.CreateCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Commands.DeleteCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Commands.UpdateCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Dtos;
using App.Application.Managements.CourseManagementAppendixs.Queries.QueryCourseManagementAppendix;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementAppendixs.Queries.FindCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Commands.DeleteCourseManagementAppendix;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程樣版附件檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementAppendixController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementAppendixController(
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
        /// 建立課程樣版附件檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagementAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementAppendixView>> CreateCourseManagementAppendix([FromBody] CreateCourseManagementAppendixCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementAppendixView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程樣版附件檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagementAppendix")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementAppendixView>> PutCourseManagementAppendix([FromBody] UpdateCourseManagementAppendixCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementAppendixView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程樣版附件檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagementAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementAppendixView>>> FindCourseManagementAppendix([FromQuery] QueryCourseManagementAppendixRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementAppendixView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 刪除課程樣版附件檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagementAppendix")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementAppendixView>> DeleteCourseManagementAppendix([FromBody] DeleteCourseManagementAppendixCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementAppendixView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementAppendix([FromRoute] DeleteCourseManagementAppendixCommand request)
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
        public async Task<ApiResponse<CourseManagementAppendixView>> GetCourseManagementAppendix([FromRoute] FindCourseManagementAppendixRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementAppendixView>()
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
        public async Task<ApiResponse<Page<CourseManagementAppendixView>>> QueryCourseManagementAppendixs(
            [FromBody] QueryCourseManagementAppendixRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementAppendixView>>()
            {
                Data = data
            };
        }



    }
}

