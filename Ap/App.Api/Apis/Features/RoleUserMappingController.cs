using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Application.Managements.Privileges.Commands.PatchPrivilege;

//using App.Application.Features.URoleUserMapping;
using App.Application.Managements.RoleUserMappings.Commands.CreateRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Commands.DeleteRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Commands.PatchRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Commands.UpdateRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Application.Managements.RoleUserMappings.Queries.FetchAllRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Queries.FindRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Queries.QueryRoleUserMapping;
using App.Application.Managements.Users.Queries.FindUser;
using App.Domain.Entities.Features;
using App.Infrastructure.Services.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 使用者角色權限
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class RoleUserMappingController : ApiControllerBase
    {
        /*
        private readonly VerificationCodeService verificationCodeService;

        public RoleUserMappingController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }
        */


        /// <summary>
        /// 建立使用者角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("createRoleUserMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleUserMappingView>> CreateRoleUserMapping([FromBody] CreateRoleUserMappingCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<RoleUserMappingView>()
                {
                    Data = data
                };
                                   
        }

        /// <summary>
        /// 修改使用者角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createRoleUserMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleUserMappingView>> PutRoleUserMapping([FromBody] UpdateRoleUserMappingCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<RoleUserMappingView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢使用者角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <RoleUserMappings></RoleUserMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createRoleUserMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RoleUserMappingView>>> GetRoleUserMapping([FromBody] QueryRoleUserMappingRequest request)
        {
            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<RoleUserMappingView>>()
            {
                Data = data
            };

            /*
            var data = await this.Mediator.Send(request);

            foreach (var RoleUserMappings in data.Records)
            {
                if (RoleUserMappings.UserId.HasValue)
                {
                    //載入使用者，根據UserId，使用 FindUserRequest採用Id查詢
                    RoleUserMappings.userView = await this.Mediator.Send(new FindUserRequest() { Id = RoleUserMappings.UserId.Value });
                }
                if (RoleUserMappings.DeviceDetailId > 0)
                {
                    //載入Device，Id一般是大於0的
                    var device = await this.Mediator.Send(new FindDeviceRequest() { Id = RoleUserMappings.DeviceDetailId });
                    RoleUserMappings.DeviceNo = device?.DeviceNo;
                    RoleUserMappings.DeviceName = device?.Name;
                }
                if (RoleUserMappings.DepartmentId > 0)
                {
                    //Department，Id一般是大於0的
                    var deparement = await this.Mediator.Send(new FindDepartmentRequest() { Id = (long)RoleUserMappings.DepartmentId });
                    RoleUserMappings.DepartmentName = deparement?.Name;
                }

                
            }
            RoleUserMapping new ApiResponse<Page<RoleUserMappingView>>()
            {
                Data = data
            };*/

        }
        /// <summary>
        /// 查詢維修單
        /// </summary>
        /// <param name="request"></param>
        /// <RoleUserMappings></RoleUserMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<RoleUserMappingView>>> FetchRoleUserMappings(
            [FromBody] FetchAllRoleUserMappingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<RoleUserMappingView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除維修單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <RoleUserMappings></RoleUserMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createRoleUserMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleUserMappingView>> DeleteRoleUserMapping([FromBody] DeleteRoleUserMappingCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<RoleUserMappingView>()
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
        public async Task<ApiResponse<int>> RemoveRoleUserMapping([FromRoute] DeleteRoleUserMappingCommand request)
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
        /// <RoleUserMappings></RoleUserMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleUserMappingView>> GetRoleUserMapping([FromRoute] FindRoleUserMappingRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<RoleUserMappingView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <RoleUserMappings></RoleUserMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RoleUserMappingView>>> QueryRoleUserMappings(
            [FromBody] QueryRoleUserMappingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<RoleUserMappingView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPatch]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleUserMappingView>> PatchRoleUserMapping([FromBody] PatchRoleUserMappingCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<RoleUserMappingView>()
            {
                Data = data
            };
        }


    }
}
