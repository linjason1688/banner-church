using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.UserCourses.Commands.CreateUserCourse;
using App.Application.Managements.UserCourses.Commands.DeleteUserCourse;
using App.Application.Managements.UserCourses.Commands.UpdateUserCourse;
using App.Application.Managements.UserCourses.Dtos;
using App.Application.Managements.UserCourses.Queries.QueryUserCourse;

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
using App.Application.Managements.UserCourses.Queries.FindUserCourse;
using App.Application.Managements.Courses.Queries.FindCourse;
using App.Domain.Entities.Features;
using App.Application.Managements.SystemConfigs.Queries.QuerySystemConfig;
using App.Application.Common.Exceptions;
using System.Linq;
using Azure.Core;
using App.Application.Managements.UserCourses.Queries.FetchAllUserCourse;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 使用者工會/課程檔主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class UserCourseController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public UserCourseController(
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
        /// 建立使用者工會/課程檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("UserCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserCourseView>> CreateUserCourse([FromBody] CreateUserCourseCommand request)
        {
            //Default 尚未開課
            request.AttendanceType = string.IsNullOrEmpty(request.AttendanceType) ? "2" : request.AttendanceType;
            //Check User & Course Id & ConfigParam
            await CheckUserCourseFields(request.UserId, request.CourseId, request.AttendanceType);

            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserCourseView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createUserCourse")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserCourseView>> PutUserCourse([FromBody] UpdateUserCourseCommand request)
        {
            //Default 尚未開課
            request.AttendanceType = string.IsNullOrEmpty(request.AttendanceType) ? "2" : request.AttendanceType;
            //Check User & Course Id & ConfigParam
            await CheckUserCourseFields(request.UserId, request.CourseId, request.AttendanceType);

            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserCourseView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createUserCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserCourseView>>> FindUserCourse([FromQuery] QueryUserCourseRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<UserCourseView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserCourseView>>> FetchUserCourses(
            [FromBody] FetchAllUserCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserCourseView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createUserCourse")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserCourseView>> DeleteUserCourse([FromBody] DeleteUserCourseCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<UserCourseView>()
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
        public async Task<ApiResponse<int>> RemoveUserCourse([FromRoute] DeleteUserCourseCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }

        /// <summary>
        /// 以 Id 查詢課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UserCourseView>> GetUserCourse([FromRoute] FindUserCourseRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserCourseView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢課程列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserCourseView>>> QueryUserCourses(
            [FromBody] QueryUserCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserCourseView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// User Course input fields
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        private async Task CheckUserCourseFields(long userId, long courseId, string type)
        {
            //Check User & Course Id & ConfigParam
            _ = await this.Mediator.Send(new FindUserRequest() { Id = userId });
            _ = await this.Mediator.Send(new FindCourseRequest() { Id = courseId });
            var sys = await this.Mediator.Send(new QuerySystemConfigRequest()
            {
                Type = "AttendanceType",
                Name = type
            });
            if (sys.TotalCount == 0)
            {
                throw new MyBusinessException($"[出席狀態]-[{type}]参数不符，请联系管理员");
            }

        }

    }
}

