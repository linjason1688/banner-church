using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.DeleteCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.UpdateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Application.Managements.CourseManagementFilterPastorals.Queries.QueryCourseManagementFilterPastoral;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagementFilterPastorals.Queries.FindCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Queries.FetchAllCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.DeleteCourseManagementFilterPastoral;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程過濾事工團主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementFilterPastoralController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementFilterPastoralController(
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
        /// 建立課程過濾事工團主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagementFilterPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterPastoralView>> CreateCourseManagementFilterPastoral([FromBody] CreateCourseManagementFilterPastoralCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterPastoralView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程過濾事工團主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagementFilterPastoral")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterPastoralView>> PutCourseManagementFilterPastoral([FromBody] UpdateCourseManagementFilterPastoralCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterPastoralView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程過濾事工團主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagementFilterPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementFilterPastoralView>>> FindCourseManagementFilterPastoral([FromQuery] QueryCourseManagementFilterPastoralRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementFilterPastoralView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢課程過濾事工團主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseManagementFilterPastoralView>>> FetchCourseManagementFilterPastorals(
            [FromBody] FetchAllCourseManagementFilterPastoralRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementFilterPastoralView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 刪除課程過濾事工團主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagementFilterPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementFilterPastoralView>> DeleteCourseManagementFilterPastoral([FromBody] DeleteCourseManagementFilterPastoralCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementFilterPastoralView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementFilterPastoral([FromRoute] DeleteCourseManagementFilterPastoralCommand request)
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
        public async Task<ApiResponse<CourseManagementFilterPastoralView>> GetCourseManagementFilterPastoral([FromRoute] FindCourseManagementFilterPastoralRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementFilterPastoralView>()
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
        public async Task<ApiResponse<Page<CourseManagementFilterPastoralView>>> QueryCourseManagementFilterPastorals(
            [FromBody] QueryCourseManagementFilterPastoralRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementFilterPastoralView>>()
            {
                Data = data
            };
        }



    }
}

