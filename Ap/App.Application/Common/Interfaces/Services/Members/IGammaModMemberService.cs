using System.Threading.Tasks;
using App.Application.Managements.Members.Commands.CreateModMember;
using App.Application.Managements.Members.ModMembers.Dtos;
using App.Application.Managements.Members.ModMembers.Queries.FindModMember;

namespace App.Application.Common.Interfaces.Services.Members
{
    /// <summary>
    /// 【MOD_MEMBER】Demo Interface
    /// </summary>
    public interface IGammaModMemberService
    {
        //實作新刪修查
        /// <summary>
        /// 單查,id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ModMemberView> GetMember(FindModMemberRequest request);

        /// <summary>
        /// 新增會員
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ModMemberView> CreateMember(CreateModMemberCommand request);
    }
}
