using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.ShoppingOrderDetails.Commands.CreateShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Commands.DeleteShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Commands.UpdateShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Dtos;
using App.Application.Managements.ShoppingOrderDetails.Queries.QueryShoppingOrderDetail;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.ShoppingOrderDetails.Queries.FindShoppingOrderDetail;
using System.Diagnostics.Metrics;
using App.Application.Managements.ShoppingOrderDetails.Queries.FetchAllShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Commands.DeleteShoppingOrderDetail;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 訂單明細主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class ShoppingOrderDetailController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public ShoppingOrderDetailController(
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
        /// 建立訂單明細主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("ShoppingOrderDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderDetailView>> CreateShoppingOrderDetail([FromBody] CreateShoppingOrderDetailCommand request)
        {
        


            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingOrderDetailView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改訂單明細主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createShoppingOrderDetail")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderDetailView>> PutShoppingOrderDetail([FromBody] UpdateShoppingOrderDetailCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingOrderDetailView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢訂單明細主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createShoppingOrderDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<ShoppingOrderDetailView>>> FindShoppingOrderDetail([FromQuery] QueryShoppingOrderDetailRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<ShoppingOrderDetailView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢訂單明細主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<ShoppingOrderDetailView>>> FetchShoppingOrderDetails(
            [FromBody] FetchAllShoppingOrderDetailRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<ShoppingOrderDetailView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 刪除訂單明細主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createShoppingOrderDetail")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderDetailView>> DeleteShoppingOrderDetail([FromBody] DeleteShoppingOrderDetailCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingOrderDetailView>()
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
        public async Task<ApiResponse<int>> RemoveShoppingOrderDetail([FromRoute] DeleteShoppingOrderDetailCommand request)
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
        public async Task<ApiResponse<ShoppingOrderDetailView>> GetShoppingOrderDetail([FromRoute] FindShoppingOrderDetailRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingOrderDetailView>()
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
        public async Task<ApiResponse<Page<ShoppingOrderDetailView>>> QueryShoppingOrderDetails(
            [FromBody] QueryShoppingOrderDetailRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<ShoppingOrderDetailView>>()
            {
                Data = data
            };
        }



    }
}

