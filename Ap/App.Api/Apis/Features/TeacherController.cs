using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.Teachers.Commands.CreateTeacher;
using App.Application.Managements.Teachers.Commands.DeleteTeacher;
using App.Application.Managements.Teachers.Commands.UpdateTeacher;
using App.Application.Managements.Teachers.Dtos;
using App.Application.Managements.Teachers.Queries.QueryTeacher;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.Teachers.Queries.FindTeacher;
using App.Application.Managements.Teachers.Queries.FetchAllTeacher;
using App.Application.Managements.Teachers.Commands.DeleteTeacher;
using App.Application.Managements.Users.Dtos;
using App.Application.Common.Interfaces.Services;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 講師主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class TeacherController : ApiControllerBase
    {
        private readonly IAuthService authService;
        private readonly UserIdentity CurrentUser;

        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public TeacherController(
            IAuthService authService,
            VerificationCodeService verificationCodeService,
            IAppDbContext appDbContext,
            IMapper mapper
        )
        {
            this.authService = authService;
            this.CurrentUser = this.authService.Identity;
            this.verificationCodeService = verificationCodeService;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        /*
        /// <summary>
        /// 建立講師主檔檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("Teacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<TeacherView>> Teacher([FromBody] CreateTeacherCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<TeacherView>()
            {
                Data = data
            };
        }
        */

        /*
        /// <summary>
        /// 修改講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createTeacher")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<TeacherView>> PutTeacher([FromBody] UpdateTeacherCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<TeacherView>()
            {
                Data = data
            };

        }
        */
        /*
        /// <summary>
        /// 查詢講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createTeacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<TeacherView>>> FindTeacher([FromQuery] QueryTeacherRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<TeacherView>>()
            {
                Data = data
            };

        }
        */


        /// <summary>
        /// 查詢講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<UserView>>> FetchTeachers(
            [FromBody] FetchAllTeacherRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<UserView>>()
            {
                Data = data
            };
        }


        /*/// <summary>
        /// 刪除講師主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createTeacher")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<TeacherView>> DeleteTeacher([FromBody] DeleteTeacherCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<TeacherView>()
            {
                //Data = data
            };

        }
        */
        /*/// <summary>
        /// 刪除主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<int>> RemoveTeacher([FromRoute] DeleteTeacherCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }
        */

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
        public async Task<ApiResponse<UserView>> GetTeacher([FromRoute] FindTeacherRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserView>()
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
        public async Task<ApiResponse<Page<UserView>>> QueryTeachers(
            [FromBody] QueryTeacherRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserView>>()
            {
                Data = data
            };
        }




    }
}

