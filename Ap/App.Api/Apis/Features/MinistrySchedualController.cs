using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.MinistrySchedules.Commands.CreateMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Commands.UpdateMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Application.Managements.MinistrySchedules.Queries.QueryMinistrySchedule;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using App.Application.Managements.MinistryScheduleDetails.Queries.QueryMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Queries.FindMinistryScheduleDetail;

using System.Collections.Generic;

using App.Application.Managements.MinistryScheduleDetails.Commands.DeleteMinistryScheduleDetail;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.MinistrySchedules.Queries.FindMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Queries.FetchAllMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 排程主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryScheduleController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public MinistryScheduleController(
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
        /// 建立排程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("MinistrySchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryScheduleView>> CreateMinistrySchedule([FromBody] CreateMinistryScheduleCommand request)
        {
            var data = await this.appDbContext.ExecuteTransactionAsync(async Task<MinistryScheduleView> () =>
            {
                var master = await this.Mediator.Send(request);

                //if (master != null && master.Id > 0)
                //{
                //    foreach (var obj in request.MinistryScheduleDetails)
                //    {
                //        obj.MinistryScheduleId = master.Id;
                //        await this.Mediator.Send(obj);
                //    }
                //}

                return master;
            });

            return new ApiResponse<MinistryScheduleView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改排程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createMinistrySchedule")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryScheduleView>> PutMinistrySchedule([FromBody] CreateMinistryScheduleCommand request)
        {
            //開個事務, appDbContext要在構造中DI進入
            var data = await this.appDbContext.ExecuteTransactionAsync(async Task<MinistryScheduleView> () =>
             {
                 //將 CreateMinistryScheduleCommand => UpdateMinistryScheduleCommand
                 //========刪除所子表的記錄，没有关联主从表，手动删除与新增==========
                 //先查出所有的子表
                 var miniRespList = await this.Mediator.Send(new QueryMinistryScheduleDetailRequest()
                 {
                     MinistryScheduleId = request.Id
                 });
                 foreach (var detail in miniRespList.Records)
                 {
                     await this.Mediator.Send(new DeleteMinistryScheduleDetailCommand()
                     {
                         Id = (int) detail.Id
                     });
                 }

                 var master = this.mapper.Map<UpdateMinistryScheduleCommand>(request);
                 //呼叫 UpdateMinistryScheduleCommandHandler 修改 主表
                 var view = await this.Mediator.Send(master);

                 ////再把request中的明细新增
                 //foreach (var obj in request.MinistryScheduleDetails)
                 //{
                 //    obj.MinistryScheduleId = master.Id;
                 //    await this.Mediator.Send(obj);
                 //}

                 return view;
             });

            return new ApiResponse<MinistryScheduleView>()
            {
                Data = data //this.mapper.Map<MinistryScheduleView>(request)
            };

        }

        /// <summary>
        /// 查詢排程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createMinistrySchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MinistryScheduleView>>> FindMinistrySchedule([FromQuery] QueryMinistryScheduleRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<MinistryScheduleView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢排程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MinistryScheduleView>>> FetchMinistrySchedules(
            [FromBody] FetchAllMinistryScheduleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MinistryScheduleView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除排程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createMinistrySchedule")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MinistryScheduleView>> DeleteMinistrySchedule([FromBody] DeleteMinistryScheduleCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<MinistryScheduleView>()
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
        public async Task<ApiResponse<int>> RemoveMinistrySchedule([FromRoute] DeleteMinistryScheduleCommand request)
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
        public async Task<ApiResponse<MinistryScheduleView>> GetMinistrySchedule([FromRoute] FindMinistryScheduleRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MinistryScheduleView>()
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
        public async Task<ApiResponse<Page<MinistryScheduleView>>> QueryMinistrySchedules(
            [FromBody] QueryMinistryScheduleRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryScheduleView>>()
            {
                Data = data
            };
        }



    }
}

