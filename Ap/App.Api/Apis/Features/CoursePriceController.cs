using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CoursePrices.Commands.CreateCoursePrice;
using App.Application.Managements.CoursePrices.Commands.DeleteCoursePrice;
using App.Application.Managements.CoursePrices.Commands.UpdateCoursePrice;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.CoursePrices.Queries.QueryCoursePrice;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CoursePrices.Queries.FindCoursePrice;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.CoursePrices.Queries.FetchAllCoursePrice;
using App.Application.Managements.CoursePrices.Commands.DeleteCoursePrice;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程價格主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CoursePriceController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CoursePriceController(
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
        /// 建立課程價格主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CoursePrice")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CoursePriceView>> CreateCoursePrice([FromBody] CreateCoursePriceCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CoursePriceView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程價格主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCoursePrice")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CoursePriceView>> PutCoursePrice([FromBody] UpdateCoursePriceCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CoursePriceView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程價格主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCoursePrice")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CoursePriceView>>> FindCoursePrice([FromQuery] QueryCoursePriceRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CoursePriceView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢價格主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CoursePriceView>>> FetchCoursePrices(
            [FromBody] FetchAllCoursePriceRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CoursePriceView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程價格主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCoursePrice")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CoursePriceView>> DeleteCoursePrice([FromBody] DeleteCoursePriceCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CoursePriceView>()
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
        public async Task<ApiResponse<int>> RemoveCoursePrice([FromRoute] DeleteCoursePriceCommand request)
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
        public async Task<ApiResponse<CoursePriceView>> GetCoursePrice([FromRoute] FindCoursePriceRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CoursePriceView>()
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
        public async Task<ApiResponse<Page<CoursePriceView>>> QueryCoursePrices(
            [FromBody] QueryCoursePriceRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CoursePriceView>>()
            {
                Data = data
            };
        }



    }
}

