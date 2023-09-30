using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.CourseManagements.Commands.CreateCourseManagement;
using App.Application.Managements.CourseManagements.Commands.DeleteCourseManagement;
using App.Application.Managements.CourseManagements.Commands.UpdateCourseManagement;
using App.Application.Managements.CourseManagements.Dtos;
using App.Application.Managements.CourseManagements.Queries.QueryCourseManagement;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.CourseManagements.Queries.FindCourseManagement;
using App.Application.Managements.CourseManagements.Dtos;
using App.Application.Managements.CourseManagements.Queries.FetchAllCourseManagement;
using App.Application.Managements.CourseManagements.Commands.DeleteCourseManagement;
using App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix;
using App.Application.Managements.Courses.Dtos;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程樣版主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseManagementController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseManagementController(
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
        /// 建立課程樣版主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("CourseManagement")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementView>> CreateCourseManagement([FromBody] CreateCourseManagementCommand request)
        {
            //检查

            var data = await this.appDbContext.ExecuteTransactionAsync(
                async Task<CourseManagementView> () =>
                {
                    var data = await this.Mediator.Send(request);

                    if (data.Id > 0)
                    {
                        foreach (var courseManagementFilters in request.CourseManagementFilters)
                        {
                            courseManagementFilters.CourseManagementId = data.Id;
                            //data.CourseManagementFilters.Add(await this.Mediator.Send(courseManagementFilters)); //過濾樣板主檔

                 

                            foreach (var courseManagementFilterResps in request.CourseManagementFilterResps)//過濾事工團職分
                            {
                                //courseManagementFilterResps.CourseManagementId = data.Id;
                                //data.CourseManagementFilterResps.Add(await this.Mediator.Send(courseManagementFilters));
                            }

                            foreach (var courseManagementFilterCourses in request.CourseManagementFilterCourses)//過濾課程
                            {
                                courseManagementFilterCourses.CourseManagementFilterId = courseManagementFilters.Id;
                                //data.CourseManagementFilterCourses.Add(await this.Mediator.Send(courseManagementFilterResps));
                            }

                            foreach (var courseManagementFilterPastorals in request.CourseManagementFilterPastorals) //過濾牧場
                            {
                                courseManagementFilterPastorals.CourseManagementFilterId = courseManagementFilters.Id;
                                //data.CourseManagementFilterPastorals.Add(await this.Mediator.Send(courseManagementFilterPastorals)); 
                            }
                            foreach (var courseManagementFilterUsers in request.CourseManagementFilterUsers) //過濾特殊會員
                            {
                                courseManagementFilterUsers.CourseManagementFilterId = courseManagementFilters.Id;
                                //data.CourseManagementFilterUsers.Add(await this.Mediator.Send(courseManagementFilterUsers)); 
                            }
                            //
                        }                        
                    }

                    return data;
                }
            );

            return new ApiResponse<CourseManagementView>()
            {
                Data = data
            };
            //var data = await this.Mediator.Send(request);

            //return new ApiResponse<CourseManagementView>()
            //{
            //    Data = data
            //};
        }

        /// <summary>
        /// 修改課程樣版主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createCourseManagement")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementView>> PutCourseManagement([FromBody] UpdateCourseManagementCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢課程樣版主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createCourseManagement")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseManagementView>>> FindCourseManagement([FromQuery] QueryCourseManagementRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<CourseManagementView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢樣板主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseManagementView>>> FetchCourseManagements(
            [FromBody] FetchAllCourseManagementRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseManagementView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程樣版主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createCourseManagement")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseManagementView>> DeleteCourseManagement([FromBody] DeleteCourseManagementCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<CourseManagementView>()
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
        public async Task<ApiResponse<int>> RemoveCourseManagement([FromRoute] DeleteCourseManagementCommand request)
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
        public async Task<ApiResponse<CourseManagementView>> GetCourseManagement([FromRoute] FindCourseManagementRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseManagementView>()
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
        public async Task<ApiResponse<Page<CourseManagementView>>> QueryCourseManagements(
            [FromBody] QueryCourseManagementRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseManagementView>>()
            {
                Data = data
            };
        }



    }
}

