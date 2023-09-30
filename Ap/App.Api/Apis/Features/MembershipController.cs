using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces.Services.Members;
using App.Application.Managements.Members.Commands.CreateModMember;
using App.Application.Managements.Members.ModMembers.Dtos;
using App.Application.Managements.Members.ModMembers.Queries.FindModMember;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 會員
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class MembershipController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;
        private readonly IGammaModMemberService gammaModMemberService;


        public MembershipController(VerificationCodeService verificationCodeService,
                                    IGammaModMemberService gammaModMemberService

            )
        {
            this.verificationCodeService = verificationCodeService;
            this.gammaModMemberService = gammaModMemberService;

        }

        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("member/findid")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ModMemberView>> FindMember([FromQuery] FindModMemberRequest request)
        {
            var data = await this.gammaModMemberService.GetMember(request);



            //var data = await this.Mediator.Send(request);

            return new ApiResponse<ModMemberView>()
            {
                Data = data
            };
        }

        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("member/createmem")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<ModMemberView>> CreateMember([FromQuery] CreateModMemberCommand request)
        {

            //var data = await this.Mediator.Send(request);

            var data = await this.gammaModMemberService.CreateMember(request);

            return new ApiResponse<ModMemberView>()
            {
                Data = data
            };
        }
    }
}
