using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Commands.DeleteCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Commands.UpdateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Application.Managements.CourseManagementFilterResps.Queries.QueryCourseManagementFilterResp;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementFilterResps.Queries.FindCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Queries.FetchAllCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Commands.DeleteCourseManagementFilterResp;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程過濾職份主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementFilterRespController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementFilterRespController(
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
        //[Route("CourseManagementFilterResp")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterRespView>> CreateCourseManagementFilterResp([FromBody] CreateCourseManagementFilterRespCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterRespView>()
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
        //[Route("createCourseManagementFilterResp")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterRespView>> PutCourseManagementFilterResp([FromBody] UpdateCourseManagementFilterRespCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterRespView>()
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
        //[Route("createCourseManagementFilterResp")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementFilterRespView>>> FindCourseManagementFilterResp([FromQuery] QueryCourseManagementFilterRespRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementFilterRespView>>()
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
        public async Task<ApiResponse<List<CourseManagementFilterRespView>>> FetchCourseManagementFilterResps(
            [FromBody] FetchAllCourseManagementFilterRespRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementFilterRespView>>()
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
        //[Route("createCourseManagementFilterResp")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterRespView>> DeleteCourseManagementFilterResp([FromBody] DeleteCourseManagementFilterRespCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementFilterRespView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementFilterResp([FromRoute] DeleteCourseManagementFilterRespCommand request)
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
        public async Task<ApiResponse<CourseManagementFilterRespView>> GetCourseManagementFilterResp([FromRoute] FindCourseManagementFilterRespRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterRespView>()
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
        public async Task<ApiResponse<Page<CourseManagementFilterRespView>>> QueryCourseManagementFilterResps(
            [FromBody] QueryCourseManagementFilterRespRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementFilterRespView>>()
            {
                Data = data
            };
        }



    }
}

