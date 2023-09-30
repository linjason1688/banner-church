using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementFilterCourses.Commands.CreateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Commands.DeleteCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Commands.UpdateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterCourses.Queries.QueryCourseManagementFilterCourse;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementFilterCourses.Queries.FindCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterCourses.Queries.FetchAllCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Commands.DeleteCourseManagementFilterCourse;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程過濾課程主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementFilterCourseController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementFilterCourseController(
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
        /// 建立課程過濾課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagementFilterCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterCourseView>> CreateCourseManagementFilterCourse([FromBody] CreateCourseManagementFilterCourseCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterCourseView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程過濾課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagementFilterCourse")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterCourseView>> PutCourseManagementFilterCourse([FromBody] UpdateCourseManagementFilterCourseCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterCourseView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程過濾課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagementFilterCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementFilterCourseView>>> FindCourseManagementFilterCourse([FromQuery] QueryCourseManagementFilterCourseRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementFilterCourseView>>()
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
        public async Task<ApiResponse<List<CourseManagementFilterCourseView>>> FetchCourseManagementFilterCourses(
            [FromBody] FetchAllCourseManagementFilterCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementFilterCourseView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程過濾課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagementFilterCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterCourseView>> DeleteCourseManagementFilterCourse([FromBody] DeleteCourseManagementFilterCourseCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementFilterCourseView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementFilterCourse([FromRoute] DeleteCourseManagementFilterCourseCommand request)
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
        public async Task<ApiResponse<CourseManagementFilterCourseView>> GetCourseManagementFilterCourse([FromRoute] FindCourseManagementFilterCourseRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterCourseView>()
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
        public async Task<ApiResponse<Page<CourseManagementFilterCourseView>>> QueryCourseManagementFilterCourses(
            [FromBody] QueryCourseManagementFilterCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementFilterCourseView>>()
            {
                Data = data
            };
        }



    }
}

