using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.ShoppingOrders.Commands.CreateShoppingOrder;
using App.Application.Managements.ShoppingOrders.Commands.DeleteShoppingOrder;
using App.Application.Managements.ShoppingOrders.Commands.UpdateShoppingOrder;
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Application.Managements.ShoppingOrders.Queries.QueryShoppingOrder;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.ShoppingOrders.Queries.FindShoppingOrder;
using System.Diagnostics.Metrics;
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Application.Managements.ShoppingOrders.Queries.FetchAllShoppingOrder;
using App.Application.Managements.ShoppingOrders.Commands.DeleteShoppingOrder;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 訂單主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class ShoppingOrderController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public ShoppingOrderController(
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
        /// 建立訂單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("ShoppingOrder")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderView>> CreateShoppingOrder([FromBody] CreateShoppingOrderCommand request)
        {
        


            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingOrderView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改訂單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createShoppingOrder")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderView>> PutShoppingOrder([FromBody] UpdateShoppingOrderCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingOrderView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢訂單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createShoppingOrder")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<ShoppingOrderView>>> FindShoppingOrder([FromQuery] QueryShoppingOrderRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<ShoppingOrderView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<ShoppingOrderView>>> FetchShoppingOrders(
            [FromBody] FetchAllShoppingOrderRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<ShoppingOrderView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除訂單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createShoppingOrder")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingOrderView>> DeleteShoppingOrder([FromBody] DeleteShoppingOrderCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingOrderView>()
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
        public async Task<ApiResponse<int>> RemoveShoppingOrder([FromRoute] DeleteShoppingOrderCommand request)
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
        public async Task<ApiResponse<ShoppingOrderView>> GetShoppingOrder([FromRoute] FindShoppingOrderRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingOrderView>()
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
        public async Task<ApiResponse<Page<ShoppingOrderView>>> QueryShoppingOrders(
            [FromBody] QueryShoppingOrderRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<ShoppingOrderView>>()
            {
                Data = data
            };
        }



    }
}

