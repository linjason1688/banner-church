using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.DeleteCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.UpdateCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Application.Managements.CourseTimeScheduleTeachers.Queries.QueryCourseTimeScheduleTeacher;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseTimeScheduleTeachers.Queries.FindCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Queries.FetchAllCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.DeleteCourseTimeScheduleTeacher;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程時段講師主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseTimeScheduleTeacherController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseTimeScheduleTeacherController(
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
        /// 建立課程時段講師主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseTimeScheduleTeacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleTeacherView>> CreateCourseTimeScheduleTeacher([FromBody] CreateCourseTimeScheduleTeacherCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleTeacherView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程時段講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseTimeScheduleTeacher")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleTeacherView>> PutCourseTimeScheduleTeacher([FromBody] UpdateCourseTimeScheduleTeacherCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleTeacherView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程時段講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseTimeScheduleTeacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseTimeScheduleTeacherView>>> FindCourseTimeScheduleTeacher([FromQuery] QueryCourseTimeScheduleTeacherRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseTimeScheduleTeacherView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢課程時段講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseTimeScheduleTeacherView>>> FetchCourseTimeScheduleTeachers(
            [FromBody] FetchAllCourseTimeScheduleTeacherRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseTimeScheduleTeacherView>>()
            {
                Data = data
            };
        }
        /// <summary>
        /// 刪除課程時段講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseTimeScheduleTeacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleTeacherView>> DeleteCourseTimeScheduleTeacher([FromBody] DeleteCourseTimeScheduleTeacherCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseTimeScheduleTeacherView>()
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
        public async Task<ApiResponse<int>> RemoveCourseTimeScheduleTeacher([FromRoute] DeleteCourseTimeScheduleTeacherCommand request)
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
        public async Task<ApiResponse<CourseTimeScheduleTeacherView>> GetCourseTimeScheduleTeacher([FromRoute] FindCourseTimeScheduleTeacherRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleTeacherView>()
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
        public async Task<ApiResponse<Page<CourseTimeScheduleTeacherView>>> QueryCourseTimeScheduleTeachers(
            [FromBody] QueryCourseTimeScheduleTeacherRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseTimeScheduleTeacherView>>()
            {
                Data = data
            };
        }




    }
}

