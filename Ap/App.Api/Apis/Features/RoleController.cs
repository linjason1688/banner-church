using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Application.Managements.Privileges.Commands.PatchPrivilege;

using App.Application.Managements.RolePrivilegeMappings.Commands.DeleteRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Queries.FetchAllRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Queries.QueryRolePrivilegeMapping;
//using App.Application.Features.URole;
using App.Application.Managements.Roles.Commands.CreateRole;
using App.Application.Managements.Roles.Commands.DeleteRole;
using App.Application.Managements.Roles.Commands.PatchRole;
using App.Application.Managements.Roles.Commands.UpdateRole;
using App.Application.Managements.Roles.Dtos;
using App.Application.Managements.Roles.Queries.FetchAllRole;
using App.Application.Managements.Roles.Queries.FindRole;
using App.Application.Managements.Roles.Queries.QueryRole;
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
    /// 角色
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class RoleController : ApiControllerBase
    {
        /*
        private readonly VerificationCodeService verificationCodeService;

        public RoleController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }
        */


        /// <summary>
        /// 建立角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("createRole")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleView>> CreateRole([FromBody] CreateRoleCommand request)
        {

            var data = await this.Mediator.Send(request);

            if (data != null && data.Id != default)
            {
                //new record
                foreach (var obj in request.RolePrivilegeList)
                {
                    obj.Id = default;
                    await this.Mediator.Send(obj);
                }

                data = await this.Mediator.Send(new FindRoleRequest()
                {
                    Id = data.Id
                });
            }
            return new ApiResponse<RoleView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createRole")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleView>> PutRole([FromBody] UpdateRoleCommand request)
        {

            var data = await this.Mediator.Send(request);

            if (data != null & data.Id != default)
            {
                //delete old record
                var lst = await this.Mediator.Send(new FetchAllRolePrivilegeMappingRequest()
                {
                    RoleId = data.Id
                });
                foreach (var obj in lst)
                {
                    await this.Mediator.Send(new DeleteRolePrivilegeMappingCommand() { Id = obj.Id });
                }

                //new record
                foreach (var obj in request.RolePrivilegeList)
                {
                    obj.Id = default;
                    await this.Mediator.Send(obj);
                }

                //refresh
                data = await this.Mediator.Send(new FindRoleRequest()
                {
                    Id = data.Id
                });
            }


            return new ApiResponse<RoleView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢角色
        /// </summary>
        /// <param name="request"></param>
        /// <Roles></Roles>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createRole")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RoleView>>> GetRole([FromBody] QueryRoleRequest request)
        {
            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<RoleView>>()
            {
                Data = data
            };

            /*
            var data = await this.Mediator.Send(request);

            foreach (var Roles in data.Records)
            {
                if (Roles.UserId.HasValue)
                {
                    //載入使用者，根據UserId，使用 FindUserRequest採用Id查詢
                    Roles.userView = await this.Mediator.Send(new FindUserRequest() { Id = Roles.UserId.Value });
                }
                if (Roles.DeviceDetailId > 0)
                {
                    //載入Device，Id一般是大於0的
                    var device = await this.Mediator.Send(new FindDeviceRequest() { Id = Roles.DeviceDetailId });
                    Roles.DeviceNo = device?.DeviceNo;
                    Roles.DeviceName = device?.Name;
                }
                if (Roles.DepartmentId > 0)
                {
                    //Department，Id一般是大於0的
                    var deparement = await this.Mediator.Send(new FindDepartmentRequest() { Id = (long)Roles.DepartmentId });
                    Roles.DepartmentName = deparement?.Name;
                }

                
            }
            Role new ApiResponse<Page<RoleView>>()
            {
                Data = data
            };*/

        }
        /// <summary>
        /// 查詢維修單
        /// </summary>
        /// <param name="request"></param>
        /// <Roles></Roles>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<RoleView>>> FetchRoles(
            [FromBody] FetchAllRoleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<RoleView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除維修單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <Roles></Roles>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createRole")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleView>> DeleteRole([FromBody] DeleteRoleCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<RoleView>()
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
        public async Task<ApiResponse<int>> RemoveRole([FromRoute] DeleteRoleCommand request)
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
        /// <Roles></Roles>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<RoleView>> GetRole([FromRoute] FindRoleRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<RoleView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <Roles></Roles>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<RoleView>>> QueryRoles(
            [FromBody] QueryRoleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<RoleView>>()
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
        public async Task<ApiResponse<RoleView>> PatchRole([FromBody] PatchRoleCommand request)
        {
            await this.Mediator.Send(new FindRoleRequest()
            {
                Id = request.Id
            });


            var data = await this.Mediator.Send(request);

            if (data != null & data.Id != default)
            {
                //delete old record
                var lst = await this.Mediator.Send(new FetchAllRolePrivilegeMappingRequest()
                {
                    RoleId = data.Id
                });
                foreach (var obj in lst)
                {
                    await this.Mediator.Send(new DeleteRolePrivilegeMappingCommand() { Id = obj.Id });
                }

                //new record
                foreach (var obj in request.RolePrivilegeList)
                {
                    obj.Id = default;
                    await this.Mediator.Send(obj);
                }

                //refresh
                data = await this.Mediator.Send(new FindRoleRequest()
                {
                    Id = data.Id
                });
            }

            return new ApiResponse<RoleView>()
            {
                Data = data
            };
        }


    }
}
