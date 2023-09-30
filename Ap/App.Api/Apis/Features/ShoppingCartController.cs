using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.ShoppingCarts.Commands.CreateShoppingCart;
using App.Application.Managements.ShoppingCarts.Commands.DeleteShoppingCart;
using App.Application.Managements.ShoppingCarts.Commands.UpdateShoppingCart;
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Application.Managements.ShoppingCarts.Queries.QueryShoppingCart;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.ShoppingCarts.Queries.FindShoppingCart;
using System.Diagnostics.Metrics;
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Application.Managements.ShoppingCarts.Queries.FetchAllShoppingCart;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 購物車主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class ShoppingCartController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public ShoppingCartController(
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
        /// 建立購物車主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("ShoppingCart")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingCartView>> CreateShoppingCart([FromBody] CreateShoppingCartCommand request)
        {
        


            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingCartView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改購物車主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createShoppingCart")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingCartView>> PutShoppingCart([FromBody] UpdateShoppingCartCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingCartView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢購物車主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createShoppingCart")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<ShoppingCartView>>> FindShoppingCart([FromQuery] QueryShoppingCartRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<ShoppingCartView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢購物車主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<ShoppingCartView>>> FetchShoppingCarts(
            [FromBody] FetchAllShoppingCartRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<ShoppingCartView>>()
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
        //[Route("createShoppingCart")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingCartView>> DeleteShoppingCart([FromBody] DeleteShoppingCartCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingCartView>()
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
        public async Task<ApiResponse<int>> RemoveShoppingCart([FromRoute] DeleteShoppingCartCommand request)
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
        public async Task<ApiResponse<ShoppingCartView>> GetShoppingCart([FromRoute] FindShoppingCartRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingCartView>()
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
        public async Task<ApiResponse<Page<ShoppingCartView>>> QueryShoppingCarts(
            [FromBody] QueryShoppingCartRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<ShoppingCartView>>()
            {
                Data = data
            };
        }



    }
}

