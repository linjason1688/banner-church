using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.CourseManagementTypes.Commands.CreateCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Commands.DeleteCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Commands.UpdateCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Dtos;
using App.Application.Managements.CourseManagementTypes.Queries.QueryCourseManagementType;
using Yozian.Extension.Pagination;
using App.Application.Managements.CourseManagementTypes.Queries.FindCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Queries.FetchAllCourseManagementType;
using System.Collections.Generic;
using App.Application.Managements.CourseManagementTypes.Commands.DeleteCourseManagementType;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程類別
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementTypeController : ApiControllerBase
    {
        /// <summary>
        /// 建立課程類別檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementTypeView>> CreateCourseManagementType(
            [FromBody] CreateCourseManagementTypeCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementTypeView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementTypeView>> PutCourseManagementType(
            [FromBody] UpdateCourseManagementTypeCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementTypeView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢課程類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementTypeView>>> FindCourseManagementType(
            [FromQuery] QueryCourseManagementTypeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementTypeView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢課程類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseManagementTypeView>>> FetchCourseManagementTypes(
            [FromBody] FetchAllCourseManagementTypeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementTypeView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程類別
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementTypeView>> DeleteCourseManagementType(
            [FromBody] DeleteCourseManagementTypeCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementTypeView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagementType([FromRoute] DeleteCourseManagementTypeCommand request)
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
        public async Task<ApiResponse<CourseManagementTypeView>> GetCourseManagementTypeOfId(
            [FromRoute] FindCourseManagementTypeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementTypeView>()
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
        public async Task<ApiResponse<Page<CourseManagementTypeView>>> QueryCourseManagementTypes(
            [FromBody] QueryCourseManagementTypeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementTypeView>>()
            {
                Data = data
            };
        }
    }
}
