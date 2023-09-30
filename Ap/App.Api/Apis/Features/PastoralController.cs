using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
//using App.Application.Features.CreatePastoral;
using App.Application.Features.UPastoral;
using App.Application.Managements.Pastorals.Commands;
using App.Application.Managements.Pastorals.Commands.CreatePastoral;
using App.Application.Managements.Pastorals.Commands.DeletePastoral;
using App.Application.Managements.Pastorals.Commands.UpdatePastoral;
using App.Application.Managements.Pastorals.Dtos;
using App.Application.Managements.Pastorals.Queries.FetchAllPastoral;
using App.Application.Managements.Pastorals.Queries.FetchPastoralFlat;
using App.Application.Managements.Pastorals.Queries.FindPastoral;
using App.Application.Managements.Pastorals.Queries.QueryPastoral;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yozian.Extension.Pagination;

//#CreateAPI
namespace App.Api.Apis.Features
{
    /// <summary>
    /// 部門牧場主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class PastoralController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        public PastoralController(
            VerificationCodeService verificationCodeService
        )
        {
            this.verificationCodeService = verificationCodeService;
        }

        
        /// <summary>
        /// 建立部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("Pastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralView>> CreatePastoral([FromBody] CreatePastoralCommand request)
        {

                var data = await this.Mediator.Send(request);

                
                return new ApiResponse<PastoralView>()
                {
                    Data = data
                };
           
            
            
        }

        /// <summary>
        /// 修改部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralView>> PutPastoral([FromBody] UpdatePastoralCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PastoralView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<PastoralView>>> FindPastoral([FromQuery] QueryPastoralRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<PastoralView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<PastoralView>>> FetchPastorals(
            [FromBody] FetchAllPastoralRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PastoralView>>()
            {
                Data = data
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
        public async Task<ApiResponse<int>> RemovePastoral([FromRoute] DeletePastoralCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }



        /// <summary>
        /// 刪除部門
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createPastoral")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralView>> DeletePastoral([FromBody] DeletePastoralCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<PastoralView>()
            {
                //Data = data
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
        public async Task<ApiResponse<Page<PastoralView>>> QueryPastorals(
            [FromBody] QueryPastoralRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<PastoralView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢Tree
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("tree/fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<PastoralTreeView>> QueryPastoralTree(
            [FromBody] QueryPastoralTreeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<PastoralTreeView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢 for Flat
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("flat/fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<PastoralView>>> FetchPastoralFlat(
            [FromBody] FetchPastoralFlatRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PastoralView>>()
            {
                Data = data
            };
        }
    }
}
