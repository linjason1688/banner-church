using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Commands.DeleteCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Commands.UpdateCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Queries.QueryCourseManagementFilterUser;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementFilterUsers.Queries.FindCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Queries.FetchAllCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Commands.DeleteCourseManagementFilterUser;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程過濾職份主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementFilterUserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementFilterUserController(
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
        /// 建立課程過濾職份主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagementFilterUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterUserView>> CreateCourseManagementFilterUser([FromBody] CreateCourseManagementFilterUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterUserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程過濾職份主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagementFilterUser")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterUserView>> PutCourseManagementFilterUser([FromBody] UpdateCourseManagementFilterUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterUserView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程過濾職份主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagementFilterUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementFilterUserView>>> FindCourseManagementFilterUser([FromQuery] QueryCourseManagementFilterUserRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementFilterUserView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢課程過濾職份主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseManagementFilterUserView>>> FetchCourseManagementFilterUsers(
            [FromBody] FetchAllCourseManagementFilterUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementFilterUserView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 刪除課程過濾職份主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagementFilterUser")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterUserView>> DeleteCourseManagementFilterUser([FromBody] DeleteCourseManagementFilterUserCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementFilterUserView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementFilterUser([FromRoute] DeleteCourseManagementFilterUserCommand request)
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
        public async Task<ApiResponse<CourseManagementFilterUserView>> GetCourseManagementFilterUser([FromRoute] FindCourseManagementFilterUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterUserView>()
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
        public async Task<ApiResponse<Page<CourseManagementFilterUserView>>> QueryCourseManagementFilterUsers(
            [FromBody] QueryCourseManagementFilterUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementFilterUserView>>()
            {
                Data = data
            };
        }



    }
}

