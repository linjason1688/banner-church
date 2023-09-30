using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Application.Managements.Privileges.Commands.PatchPrivilege;

//using App.Application.Features.URolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Commands.DeleteRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Commands.PatchRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Commands.UpdateRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using App.Application.Managements.RolePrivilegeMappings.Queries.FetchAllRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Queries.FindRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Queries.QueryRolePrivilegeMapping;
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
    /// 角色權限
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class RolePrivilegeMappingController : ApiControllerBase
    {
        /*
        private readonly VerificationCodeService verificationCodeService;

        public RolePrivilegeMappingController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }
        */


        /// <summary>
        /// 建立角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("createRolePrivilegeMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RolePrivilegeMappingView>> CreateRolePrivilegeMapping([FromBody] CreateRolePrivilegeMappingCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<RolePrivilegeMappingView>()
                {
                    Data = data
                };
                                   
        }

        /// <summary>
        /// 修改角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createRolePrivilegeMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RolePrivilegeMappingView>> PutRolePrivilegeMapping([FromBody] UpdateRolePrivilegeMappingCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<RolePrivilegeMappingView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢角色權限
        /// </summary>
        /// <param name="request"></param>
        /// <RolePrivilegeMappings></RolePrivilegeMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createRolePrivilegeMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RolePrivilegeMappingView>>> GetRolePrivilegeMapping([FromBody] QueryRolePrivilegeMappingRequest request)
        {
            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<RolePrivilegeMappingView>>()
            {
                Data = data
            };

            /*
            var data = await this.Mediator.Send(request);

            foreach (var RolePrivilegeMappings in data.Records)
            {
                if (RolePrivilegeMappings.UserId.HasValue)
                {
                    //載入使用者，根據UserId，使用 FindUserRequest採用Id查詢
                    RolePrivilegeMappings.userView = await this.Mediator.Send(new FindUserRequest() { Id = RolePrivilegeMappings.UserId.Value });
                }
                if (RolePrivilegeMappings.DeviceDetailId > 0)
                {
                    //載入Device，Id一般是大於0的
                    var device = await this.Mediator.Send(new FindDeviceRequest() { Id = RolePrivilegeMappings.DeviceDetailId });
                    RolePrivilegeMappings.DeviceNo = device?.DeviceNo;
                    RolePrivilegeMappings.DeviceName = device?.Name;
                }
                if (RolePrivilegeMappings.DepartmentId > 0)
                {
                    //Department，Id一般是大於0的
                    var deparement = await this.Mediator.Send(new FindDepartmentRequest() { Id = (long)RolePrivilegeMappings.DepartmentId });
                    RolePrivilegeMappings.DepartmentName = deparement?.Name;
                }

                
            }
            RolePrivilegeMapping new ApiResponse<Page<RolePrivilegeMappingView>>()
            {
                Data = data
            };*/

        }
        /// <summary>
        /// 查詢維修單
        /// </summary>
        /// <param name="request"></param>
        /// <RolePrivilegeMappings></RolePrivilegeMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<RolePrivilegeMappingView>>> FetchRolePrivilegeMappings(
            [FromBody] FetchAllRolePrivilegeMappingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<RolePrivilegeMappingView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除維修單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <RolePrivilegeMappings></RolePrivilegeMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createRolePrivilegeMapping")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RolePrivilegeMappingView>> DeleteRolePrivilegeMapping([FromBody] DeleteRolePrivilegeMappingCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<RolePrivilegeMappingView>()
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
        public async Task<ApiResponse<int>> RemoveRolePrivilegeMapping([FromRoute] DeleteRolePrivilegeMappingCommand request)
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
        /// <RolePrivilegeMappings></RolePrivilegeMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RolePrivilegeMappingView>> GetRolePrivilegeMapping([FromRoute] FindRolePrivilegeMappingRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<RolePrivilegeMappingView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <RolePrivilegeMappings></RolePrivilegeMappings>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RolePrivilegeMappingView>>> QueryRolePrivilegeMappings(
            [FromBody] QueryRolePrivilegeMappingRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<RolePrivilegeMappingView>>()
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
        public async Task<ApiResponse<RolePrivilegeMappingView>> PatchRolePrivilegeMapping([FromBody] PatchRolePrivilegeMappingCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<RolePrivilegeMappingView>()
            {
                Data = data
            };
        }


    }
}
