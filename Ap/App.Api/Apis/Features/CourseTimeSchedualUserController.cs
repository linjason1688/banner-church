using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseTimeScheduleUsers.Commands.CreateCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Commands.DeleteCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Commands.UpdateCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Dtos;
using App.Application.Managements.CourseTimeScheduleUsers.Queries.QueryCourseTimeScheduleUser;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseTimeScheduleUsers.Queries.FindCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Dtos;
using App.Application.Managements.CourseTimeScheduleUsers.Queries.FetchAllCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Commands.DeleteCourseTimeScheduleUser;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程時段學員主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseTimeScheduleUserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseTimeScheduleUserController(
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
        /// 建立課程時段學員主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseTimeScheduleUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleUserView>> CreateCourseTimeScheduleUser([FromBody] CreateCourseTimeScheduleUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程時段學員主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseTimeScheduleUser")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleUserView>> PutCourseTimeScheduleUser([FromBody] UpdateCourseTimeScheduleUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleUserView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程時段學員主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseTimeScheduleUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseTimeScheduleUserView>>> FindCourseTimeScheduleUser([FromQuery] QueryCourseTimeScheduleUserRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseTimeScheduleUserView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程時段學員主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseTimeScheduleUserView>>> FetchCourseTimeScheduleUsers(
            [FromBody] FetchAllCourseTimeScheduleUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseTimeScheduleUserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程時段學員主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseTimeScheduleUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseTimeScheduleUserView>> DeleteCourseTimeScheduleUser([FromBody] DeleteCourseTimeScheduleUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseTimeScheduleUserView>()
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
        public async Task<ApiResponse<int>> RemoveCourseTimeScheduleUser([FromRoute] DeleteCourseTimeScheduleUserCommand request)
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
        public async Task<ApiResponse<CourseTimeScheduleUserView>> GetCourseTimeScheduleUser([FromRoute] FindCourseTimeScheduleUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseTimeScheduleUserView>()
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
        public async Task<ApiResponse<Page<CourseTimeScheduleUserView>>> QueryCourseTimeScheduleUsers(
            [FromBody] QueryCourseTimeScheduleUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseTimeScheduleUserView>>()
            {
                Data = data
            };
        }




    }
}

