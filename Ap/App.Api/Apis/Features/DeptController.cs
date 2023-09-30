using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.Depts.Commands.CreateDept;
using App.Application.Managements.Depts.Commands.DeleteDept;
using App.Application.Managements.Depts.Commands.UpdateDept;
using App.Application.Managements.Depts.Dtos;
using App.Application.Managements.Depts.Queries.FetchAllDept;
using App.Application.Managements.Depts.Queries.QueryDept;
using App.Application.Managements.Depts.Queries.FindDept;
using MediatR;
using Yozian.Extension.Pagination;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 組織部門主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class DeptController : ApiControllerBase
    {
        /// <summary>
        /// 建立組織部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]

        //[Route("Dept")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<DeptView>> CreateDept(
            [FromBody] CreateDeptCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            /*
            foreach (var obj in request.DeptResps)
            {
                //TODO DeptRespUser尚未放入
                foreach (var obj2 in obj.DeptRespUsers)
                {
                    //obj2.DeptRespId=obj.Id
                    await this.Mediator.Send(obj2);
                }
                await this.Mediator.Send(obj);                                             
            }    
            */
            return new ApiResponse<DeptView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改組織部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]

        //[Route("createDept")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<DeptView>> PutDept([FromBody] UpdateDeptCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<DeptView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢組織部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]

        //[Route("createDept")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<DeptView>>> FindDepts(
            [FromQuery] QueryDeptRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<DeptView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢組織部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<DeptView>>> FetchDepts(
            [FromBody] FetchAllDeptRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<DeptView>>()
            {
                Data = data
            };
        }

        

        /// <summary>
        /// 刪除組織部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]

        //[Route("createDept")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<DeptView>> DeleteDept(
            [FromBody] DeleteDeptCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<DeptView>()
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
        public async Task<ApiResponse<int>> RemoveDept([FromRoute] DeleteDeptCommand request)
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
        public async Task<ApiResponse<DeptView>> GetDept([FromRoute] FindDeptRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<DeptView>()
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
        public async Task<ApiResponse<Page<DeptView>>> QueryDepts(
            [FromBody] QueryDeptRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<DeptView>>()
            {
                Data = data
            };
        }
    }
}
