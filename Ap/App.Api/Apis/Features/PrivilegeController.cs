using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Application.Managements.Privileges.Commands.CreatePrivilege;
using App.Application.Managements.Privileges.Commands.DeletePrivilege;
using App.Application.Managements.Privileges.Commands.PatchPrivilege;
using App.Application.Managements.Privileges.Commands.UpdatePrivilege;
using App.Application.Managements.Privileges.Dtos;
using App.Application.Managements.Privileges.Queries.FetchAllPrivilege;
using App.Application.Managements.Privileges.Queries.FindPrivilege;
using App.Application.Managements.Privileges.Queries.QueryPrivilege;
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
    public class PrivilegeController : ApiControllerBase
    {
        /*
        private readonly VerificationCodeService verificationCodeService;

        public PrivilegeController(
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
        //[Route("createPrivilege")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PrivilegeView>> CreatePrivilege([FromBody] CreatePrivilegeCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<PrivilegeView>()
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
        //[Route("createPrivilege")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PrivilegeView>> PutPrivilege([FromBody] UpdatePrivilegeCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PrivilegeView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢角色
        /// </summary>
        /// <param name="request"></param>
        /// <Privileges></Privileges>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createPrivilege")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<PrivilegeView>>> GetPrivilege([FromBody] QueryPrivilegeRequest request)
        {
            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<PrivilegeView>>()
            {
                Data = data
            };

            /*
            var data = await this.Mediator.Send(request);

            foreach (var Privileges in data.Records)
            {
                if (Privileges.UserId.HasValue)
                {
                    //載入使用者，根據UserId，使用 FindUserRequest採用Id查詢
                    Privileges.userView = await this.Mediator.Send(new FindUserRequest() { Id = Privileges.UserId.Value });
                }
                if (Privileges.DeviceDetailId > 0)
                {
                    //載入Device，Id一般是大於0的
                    var device = await this.Mediator.Send(new FindDeviceRequest() { Id = Privileges.DeviceDetailId });
                    Privileges.DeviceNo = device?.DeviceNo;
                    Privileges.DeviceName = device?.Name;
                }
                if (Privileges.DepartmentId > 0)
                {
                    //Department，Id一般是大於0的
                    var deparement = await this.Mediator.Send(new FindDepartmentRequest() { Id = (long)Privileges.DepartmentId });
                    Privileges.DepartmentName = deparement?.Name;
                }

                
            }
            Privilege new ApiResponse<Page<PrivilegeView>>()
            {
                Data = data
            };*/

        }
        /// <summary>
        /// 查詢維修單
        /// </summary>
        /// <param name="request"></param>
        /// <Privileges></Privileges>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<List<PrivilegeView>>> FetchPrivileges(
            [FromBody] FetchAllPrivilegeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PrivilegeView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除維修單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <Privileges></Privileges>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createPrivilege")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PrivilegeView>> DeletePrivilege([FromBody] DeletePrivilegeCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PrivilegeView>()
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
        public async Task<ApiResponse<int>> RemovePrivilege([FromRoute] DeletePrivilegeCommand request)
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
        /// <Privileges></Privileges>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PrivilegeView>> GetPrivilege([FromRoute] FindPrivilegeRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PrivilegeView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <Privileges></Privileges>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<PrivilegeView>>> QueryPrivileges(
            [FromBody] QueryPrivilegeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<PrivilegeView>>()
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
        public async Task<ApiResponse<PrivilegeView>> PatchPrivilege([FromBody] PatchPrivilegeCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PrivilegeView>()
            {
                Data = data
            };
        }


    }
}
