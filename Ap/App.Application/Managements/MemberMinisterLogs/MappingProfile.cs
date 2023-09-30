using AutoMapper;
using App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.CreateModMemberMinisterLog;
using App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.UpdateModMemberMinisterLog;
using App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ModMemberMinisterLog, ModMemberMinisterLogView>();
            
            CreateMap<CreateModMemberMinisterLogCommand, ModMemberMinisterLog>();
            
            CreateMap<UpdateModMemberMinisterLogCommand, ModMemberMinisterLog>();
            
        }
    }
}
