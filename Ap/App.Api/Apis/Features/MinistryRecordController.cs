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
using App.Domain.Entities.Features;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 事工團類別主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MinistryRecordController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public MinistryRecordController(
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
        /// 查詢所有事工團會議及異動清單
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
            /*select * from (select M.Id as   MinistryId,M.Name as MinistryName,MR.Id as MinistryRespID,MR.Name as MinistryRespName from Ministry M , MinistryResp MR  
                Left join   MinistryRespUser MRU on MR.Id = MRU.MinistryRespId
                where M.Id = MR.MinistryId
                ) as c
                Left join   MinistryMeeting MT on MT.MinistryId = c.MinistryId
                Left join   MinistryMeetingUser MMU on MT.Id = MMU.MinistryMeetingId
            */
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MinistryView>>()
            {
                Data = data
            };
        }





    }
}
