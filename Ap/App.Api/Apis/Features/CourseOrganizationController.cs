using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseOrganizations.Commands.CreateCourseOrganization;
using App.Application.Managements.CourseOrganizations.Commands.DeleteCourseOrganization;
using App.Application.Managements.CourseOrganizations.Commands.UpdateCourseOrganization;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.CourseOrganizations.Queries.QueryCourseOrganization;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseOrganizations.Queries.FindCourseOrganization;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.CourseOrganizations.Queries.FetchAllCourseOrganization;
using App.Application.Managements.CourseOrganizations.Commands.DeleteCourseOrganization;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程堂點主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseOrganizationController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseOrganizationController(
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
        /// 建立課程堂點主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseOrganizationView>> CreateCourseOrganization([FromBody] CreateCourseOrganizationCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseOrganizationView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程堂點主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseOrganization")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseOrganizationView>> PutCourseOrganization([FromBody] UpdateCourseOrganizationCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseOrganizationView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程堂點主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseOrganizationView>>> FindCourseOrganization([FromQuery] QueryCourseOrganizationRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseOrganizationView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢堂點主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseOrganizationView>>> FetchCourseOrganizations(
            [FromBody] FetchAllCourseOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseOrganizationView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程堂點主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseOrganizationView>> DeleteCourseOrganization([FromBody] DeleteCourseOrganizationCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseOrganizationView>()
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
        public async Task<ApiResponse<int>> RemoveCourseOrganization([FromRoute] DeleteCourseOrganizationCommand request)
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
        public async Task<ApiResponse<CourseOrganizationView>> GetCourseOrganization([FromRoute] FindCourseOrganizationRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseOrganizationView>()
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
        public async Task<ApiResponse<Page<CourseOrganizationView>>> QueryCourseOrganizations(
            [FromBody] QueryCourseOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseOrganizationView>>()
            {
                Data = data
            };
        }



    }
}

