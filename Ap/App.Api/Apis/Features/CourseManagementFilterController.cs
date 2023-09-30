using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Commands.DeleteCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Commands.UpdateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Application.Managements.CourseManagementFilters.Queries.QueryCourseManagementFilter;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementFilters.Queries.FindCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Queries.FetchAllCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Queries.FetchAllCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Commands.DeleteCourseManagementFilter;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程過濾主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementFilterController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementFilterController(
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
        /// 建立課程過濾主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagementFilter")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterView>> CreateCourseManagementFilter([FromBody] CreateCourseManagementFilterCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程過濾主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagementFilter")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterView>> PutCourseManagementFilter([FromBody] UpdateCourseManagementFilterCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程過濾主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagementFilter")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementFilterView>>> FindCourseManagementFilter([FromQuery] QueryCourseManagementFilterRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementFilterView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程過濾主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseManagementFilterView>>> FetchCourseManagementFilters(
            [FromBody] FetchAllCourseManagementFilterRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementFilterView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程過濾主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagementFilter")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterView>> DeleteCourseManagementFilter([FromBody] DeleteCourseManagementFilterCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementFilterView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementFilter([FromRoute] DeleteCourseManagementFilterCommand request)
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
        public async Task<ApiResponse<CourseManagementFilterView>> GetCourseManagementFilter([FromRoute] FindCourseManagementFilterRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterView>()
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
        public async Task<ApiResponse<Page<CourseManagementFilterView>>> QueryCourseManagementFilters(
            [FromBody] QueryCourseManagementFilterRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementFilterView>>()
            {
                Data = data
            };
        }



    }
}

