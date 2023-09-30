using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.Courses.Commands.CreateCourse;
using App.Application.Managements.Courses.Commands.DeleteCourse;
using App.Application.Managements.Courses.Commands.UpdateCourse;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.Courses.Queries.QueryCourse;
using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using App.Application.Managements.Courses.Queries.FindCourse;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.Courses.Queries.FetchAllCourse;
using System.Collections.Generic;
using App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Application.Managements.Courses.Commands.DeleteCourse;
using App.Domain.Entities.Features;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 課程主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class CourseController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public CourseController(
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
        /// 建立課程主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseView>> CreateCourse([FromBody] CreateCourseCommand request)
        {
            //检查

            //Todo 新增CourseManagementfilter        
            var filter = await this.Mediator.Send(request.CourseManagementFilter);
            if (filter != null)
            {
                request.CourseManagementFilterId= filter.Id;


            }
            var data = await this.appDbContext.ExecuteTransactionAsync(
                async Task<CourseView>() =>
                {


                    var data = await this.Mediator.Send(request);

                    if (data.Id > 0)
                    {

                        //Todo 新增CourseManagementfilter        
                        var filter = await this.Mediator.Send(request.CourseManagementFilter);
                        

                            if (filter.Id > 0)
                            {
                                //request.CourseManagementFilterId = filter.Id;
                                //var upData = this.mapper.Map<UpdateCourseCommand>(data);
                                //upData.CourseManagementFilterId = filter.Id;
                                //await this.Mediator.Send(upData);

                                foreach (var courseManagementFilterResps in request.CourseManagementFilter.CourseManagementFilterResps)
                                {
                                    try
                                    {
                                        courseManagementFilterResps.CourseManagementFilterId = filter.Id;
                                        data.CourseManagementFilter.CourseManagementFilterResps.Add(await this.Mediator.Send(courseManagementFilterResps));
                                    }
                                    catch { }

                                }
                                foreach (var courseManagementFilterCourses in request.CourseManagementFilter.CourseManagementFilterCourses)
                                {
                                    try
                                    {
                                        courseManagementFilterCourses.CourseManagementFilterId = filter.Id;
                                        data.CourseManagementFilter.CourseManagementFilterCourses.Add(await this.Mediator.Send(courseManagementFilterCourses));
                                    }
                                    catch { }
                                }
                                foreach (var courseManagementFilterUsers in request.CourseManagementFilter.CourseManagementFilterUsers)
                                {
                                    try
                                    {
                                        courseManagementFilterUsers.CourseManagementFilterId = filter.Id;
                                        data.CourseManagementFilter.CourseManagementFilterUsers.Add(await this.Mediator.Send(courseManagementFilterUsers));
                                    }
                                    catch { }
                                }
                            }

                        
                      

                        foreach (var CourseO in request.CourseOrganizations)
                        {
                            CourseO.CourseId = data.Id;
                            data.CourseOrganizations.Add(await this.Mediator.Send(CourseO)); //堂點
                        }

                        foreach (var price in request.CoursePrices)
                        {
                            price.CourseId = data.Id;
                            data.CoursePrices.Add(await this.Mediator.Send(price)); //价格
                        }

                        foreach (var ts in request.CourseTimeSchedules)
                        {
                            ts.CourseId = data.Id;
                            var t = await this.Mediator.Send(ts);

                            if (t.Id > 0)
                            {
                                foreach (var teach in ts.CourseTimeScheduleTeachers)
                                {
                                    teach.CourseTimeScheduleId = t.Id;
                                    t.CourseTimeScheduleTeachers.Add(await this.Mediator.Send(teach));
                                }
                            }

                            data.CourseTimeSchedules.Add(t);
                        }

                        if (request.CourseAppendices != null)
                        {
                            foreach (var e in request.CourseAppendices)
                            {
                                await this.Mediator.Send(
                                    new CreateCourseAppendixCommand()
                                    {
                                        CourseId = data.Id,
                                        Path = e.Path,
                                        AppendixType = e.AppendixType,
                                    }
                                );
                            }
                        }
                    }

                    return data;
                }
            );

            return new ApiResponse<CourseView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseView>> PutCourse([FromBody] UpdateCourseCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<CourseView>>> FindCourse([FromQuery] QueryCourseRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseView>>()
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
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<CourseView>>> FetchCourses(
            [FromBody] FetchAllCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<CourseView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除課程主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<CourseView>> DeleteCourse([FromBody] DeleteCourseCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseView>()
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
        public async Task<ApiResponse<int>> RemoveCourse([FromRoute] DeleteCourseCommand request)
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
        public async Task<ApiResponse<CourseView>> GetCourse([FromRoute] FindCourseRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<CourseView>()
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
        public async Task<ApiResponse<Page<CourseView>>> QueryCourses(
            [FromBody] QueryCourseRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<CourseView>>()
            {
                Data = data
            };
        }
    }
}
