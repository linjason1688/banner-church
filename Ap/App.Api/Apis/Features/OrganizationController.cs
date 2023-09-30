using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.Organizations.Commands.CreateOrganization;
using App.Application.Managements.Organizations.Commands.DeleteOrganization;
using App.Application.Managements.Organizations.Commands.UpdateOrganization;
using App.Application.Managements.Organizations.Dtos;
using App.Application.Managements.Organizations.Queries.FetchAllOrganization;
using App.Application.Managements.Organizations.Queries.QueryOrganization;
using App.Application.Managements.Organizations.Queries.FindOrganization;
using MediatR;
using Yozian.Extension.Pagination;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 教會組織主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class OrganizationController : ApiControllerBase
    {
        /// <summary>
        /// 建立教會組織
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]

        //[Route("Organization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<OrganizationView>> CreateOrganization(
            [FromBody] CreateOrganizationCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            /*
            foreach (var obj in request.OrganizationResps)
            {
                //TODO OrganizationRespUser尚未放入
                foreach (var obj2 in obj.OrganizationRespUsers)
                {
                    //obj2.OrganizationRespId=obj.Id
                    await this.Mediator.Send(obj2);
                }
                await this.Mediator.Send(obj);                                             
            }    
            */
            return new ApiResponse<OrganizationView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改教會組織
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]

        //[Route("createOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<OrganizationView>> PutOrganization([FromBody] UpdateOrganizationCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<OrganizationView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢教會組織
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]

        //[Route("createOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<OrganizationView>>> FindOrganizations(
            [FromQuery] QueryOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<OrganizationView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢教會組織 By註冊使用 不檢查權限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("anonymous/fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<List<OrganizationView>>> FetchOrganizations2(
            [FromBody] FetchAllOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<OrganizationView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢教會組織
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<OrganizationView>>> FetchOrganizations(
            [FromBody] FetchAllOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<OrganizationView>>()
            {
                Data = data
            };
        }

        

        /// <summary>
        /// 刪除教會組織
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]

        //[Route("createOrganization")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<OrganizationView>> DeleteOrganization(
            [FromBody] DeleteOrganizationCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<OrganizationView>()
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
        public async Task<ApiResponse<int>> RemoveOrganization([FromRoute] DeleteOrganizationCommand request)
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
        public async Task<ApiResponse<OrganizationView>> GetOrganization([FromRoute] FindOrganizationRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<OrganizationView>()
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
        public async Task<ApiResponse<Page<OrganizationView>>> QueryOrganizations(
            [FromBody] QueryOrganizationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<OrganizationView>>()
            {
                Data = data
            };
        }
    }
}
