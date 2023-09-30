using System.Threading.Tasks;
using App.Application.Common.Interfaces.Services.Members;
using App.Application.Managements.Members.Commands.CreateModMember;
using App.Application.Managements.Members.ModMembers.Dtos;
using App.Application.Managements.Members.ModMembers.Queries.FindModMember;
using AutoMapper;
using MediatR;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Members
{
    /// <summary>
    /// 【MOD_MEMBER】Demo Service
    /// </summary>
    [ScopedService(typeof(IGammaModMemberService))]
    public class GammaModMemberService : IGammaModMemberService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public GammaModMemberService(
            IMapper mapper,
            IMediator mediator
        )
        {
            this.mapper = mapper;

            //find和create可用di，或直接new也行
            this.mediator = mediator;
        }

        /// <summary>
        /// 查 单个会员，根据id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ModMemberView> GetMember(FindModMemberRequest request)
        {
            var obj = await this.mediator.Send(request);

            return this.mapper.Map<ModMemberView>(obj);
        }

        /// <summary>
        /// 新增 单个会员
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ModMemberView> CreateMember(CreateModMemberCommand request)
        {
            var obj = await this.mediator.Send(request);

            return this.mapper.Map<ModMemberView>(obj);
        }
    }
}
