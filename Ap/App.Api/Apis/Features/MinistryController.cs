using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Features.UMinistry;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.Ministries.Commands.DeleteMinistry;
using App.Application.Managements.Ministries.Commands.UpdateMinistry;
using App.Application.Managements.Ministries.Dtos;
using App.Application.Managements.Ministries.Queries.QueryMinistry;
using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using App.Application.Managements.Ministries.Queries.FindMinistry;
using AutoMapper;
using App.Application.Managements.MinistryResps.Queries.QueryMinistryResp;
using App.Application.Managements.MinistryRespUsers.Queries.QueryMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Commands.DeleteMinistryRespUser;
using App.Application.Managements.MinistryResps.Commands.DeleteMinistryResp;

using App.Application.Managements.Ministries.Queries.FetchAllMinistry;
using System.Collections.Generic;


namespace App.Api.Apis.Features
{
    /// <summary>
    /// 事工團類別主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public MinistryController(
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
        /// 建立事工團
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UMinistryCommandResponse>> CreateMinistry([FromBody] UMinistryCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UMinistryCommandResponse>()
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
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryView>> PutMinistry([FromBody] UMinistryCommand request)
        {
            //開個事務, appDbContext要在構造中DI進入
            await this.appDbContext.ExecuteTransactionAsync(
                async Task() =>
                {
                    //將 UMinistryCommand => UpdateMinistryCommand
                    var master = this.mapper.Map<UpdateMinistryCommand>(request);

                    //呼叫 UpdateMinistryCommandHandler 修改 主表
                    await this.Mediator.Send(master);

                    //========刪除所子表的記錄==========
                    var miniRespList = await this.Mediator.Send(
                        new QueryMinistryRespRequest()
                        {
                            MinistryId = master.Id
                        }
                    );

                    foreach (var resp in miniRespList.Records)
                    {
                        //查出【MinistryRespUser】關聯的記錄
                        var respUsers = await this.Mediator.Send(
                            new QueryMinistryRespUserRequest()
                            {
                                MinistryRespId = resp.Id
                            }
                        );

                        foreach (var user in respUsers.Records)
                        {
                            //暫放task list中
                            await this.Mediator.Send(
                                new DeleteMinistryRespUserCommand()
                                {
                                    Id = user.Id
                                }
                            );
                        }

                        await this.Mediator.Send(
                            new DeleteMinistryRespCommand()
                            {
                                Id = resp.Id
                            }
                        );
                    }

                    //========新增Request中的子表記錄====
                    foreach (var resp in request.MinistryResps)
                    {
                        resp.MinistryId = request.Id; //fix db to long after
                        var r = await this.Mediator.Send(resp);  //生成新的子表記錄【MinistryResp】

                        if (resp.MinistryRespUsers != null)
                        {
                            foreach (var user in resp.MinistryRespUsers)
                            {
                                user.MinistryRespId = r.Id;
                                await this.Mediator.Send(user);
                            }
                        }
                    }
                }
            );

            return new ApiResponse<MinistryView>()
            {
                Data = this.mapper.Map<MinistryView>(request)
            };
        }
        
        /// <summary>
        /// 以 Id 查詢用戶資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryView>> GetMinistry([FromRoute] FindMinistryRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryView>()
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
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryView>>> FindMinistry([FromQuery] QueryMinistryRequest request)
        {
            //要改變排序，可在request中針對SortProperties加入欄位與方式
            //request.SortProperties.Add(new SortProperty() { PropertyName = "Id", SortOrder = SortOrder.Asc });
            //默認是沒有排序的，會使用CreateAt做為排序

            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryView>>()
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
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryView>>> QueryMinistry([FromBody] QueryMinistryRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryView>>()
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
        public async Task<ApiResponse<List<MinistryView>>> FetchMinistrys(
            [FromBody] FetchAllMinistryRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryView>>()
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
        public async Task<ApiResponse<int>> RemoveMinistry([FromRoute] DeleteMinistryCommand request)
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
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryView>> DeleteMinistry([FromBody] DeleteMinistryCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryView>()
            {
                //Data = data
            };
        }


        /// <summary>
        /// 查詢所有事工團會議及異動清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("queryRecord")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryView>>> QueryMinistryRecord([FromBody] QueryMinistryRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryView>>()
            {
                Data = data
            };
        }
    }
}
