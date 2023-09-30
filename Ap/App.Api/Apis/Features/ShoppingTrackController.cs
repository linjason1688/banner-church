using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.ShoppingTracks.Commands.CreateShoppingTrack;
using App.Application.Managements.ShoppingTracks.Commands.DeleteShoppingTrack;
using App.Application.Managements.ShoppingTracks.Commands.UpdateShoppingTrack;
using App.Application.Managements.ShoppingTracks.Dtos;
using App.Application.Managements.ShoppingTracks.Queries.QueryShoppingTrack;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.ShoppingTracks.Queries.FindShoppingTrack;
using System.Diagnostics.Metrics;
using App.Application.Managements.ShoppingTracks.Dtos;
using App.Application.Managements.ShoppingTracks.Queries.FetchAllShoppingTrack;
using App.Application.Managements.ShoppingTracks.Commands.DeleteShoppingTrack;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 追蹤清單主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class ShoppingTrackController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public ShoppingTrackController(
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
        /// 建立追蹤清單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("ShoppingTrack")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingTrackView>> CreateShoppingTrack([FromBody] CreateShoppingTrackCommand request)
        {
        


            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingTrackView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改追蹤清單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createShoppingTrack")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingTrackView>> PutShoppingTrack([FromBody] UpdateShoppingTrackCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingTrackView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢追蹤清單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createShoppingTrack")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<ShoppingTrackView>>> FindShoppingTrack([FromQuery] QueryShoppingTrackRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<ShoppingTrackView>>()
            {
                Data = data
            };

        }


        /// <summary>
        /// 查詢追蹤清單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<ShoppingTrackView>>> FetchShoppingTracks(
            [FromBody] FetchAllShoppingTrackRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<ShoppingTrackView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除追蹤清單主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createShoppingTrack")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ShoppingTrackView>> DeleteShoppingTrack([FromBody] DeleteShoppingTrackCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<ShoppingTrackView>()
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
        public async Task<ApiResponse<int>> RemoveShoppingTrack([FromRoute] DeleteShoppingTrackCommand request)
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
        public async Task<ApiResponse<ShoppingTrackView>> GetShoppingTrack([FromRoute] FindShoppingTrackRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ShoppingTrackView>()
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
        public async Task<ApiResponse<Page<ShoppingTrackView>>> QueryShoppingTracks(
            [FromBody] QueryShoppingTrackRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<ShoppingTrackView>>()
            {
                Data = data
            };
        }



    }
}

