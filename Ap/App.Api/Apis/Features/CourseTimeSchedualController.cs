using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseTimeSchedules.Commands.CreateCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Commands.DeleteCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Commands.UpdateCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.CourseTimeSchedules.Queries.QueryCourseTimeSchedule;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseTimeSchedules.Queries.FindCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Queries.FetchAllCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Commands.DeleteCourseTimeSchedule;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程時段主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseTimeScheduleController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseTimeScheduleController(
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
        /// 建立課程時段主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseTimeSchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleView>> CreateCourseTimeSchedule([FromBody] CreateCourseTimeScheduleCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程時段主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseTimeSchedule")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleView>> PutCourseTimeSchedule([FromBody] UpdateCourseTimeScheduleCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程時段主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseTimeSchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseTimeScheduleView>>> FindCourseTimeSchedule([FromQuery] QueryCourseTimeScheduleRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseTimeScheduleView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢課程時段主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseTimeScheduleView>>> FetchCourseTimeSchedules(
            [FromBody] FetchAllCourseTimeScheduleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseTimeScheduleView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 刪除課程時段主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseTimeSchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleView>> DeleteCourseTimeSchedule([FromBody] DeleteCourseTimeScheduleCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseTimeScheduleView>()
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
        public async Task<ApiResponse<int>> RemoveCourseTimeSchedule([FromRoute] DeleteCourseTimeScheduleCommand request)
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
        public async Task<ApiResponse<CourseTimeScheduleView>> GetCourseTimeSchedule([FromRoute] FindCourseTimeScheduleRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleView>()
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
        public async Task<ApiResponse<Page<CourseTimeScheduleView>>> QueryCourseTimeSchedules(
            [FromBody] QueryCourseTimeScheduleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseTimeScheduleView>>()
            {
                Data = data
            };
        }



    }
}

