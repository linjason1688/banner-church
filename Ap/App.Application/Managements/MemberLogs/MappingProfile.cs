using AutoMapper;
using App.Application.Managements.MemberLogs.ModMemberLogs.Commands.CreateModMemberLog;
using App.Application.Managements.MemberLogs.ModMemberLogs.Commands.UpdateModMemberLog;
using App.Application.Managements.MemberLogs.ModMemberLogs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberLogs.ModMemberLogs
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
            CreateMap<ModMemberLog, ModMemberLogView>();
            
            CreateMap<CreateModMemberLogCommand, ModMemberLog>();
            
            CreateMap<UpdateModMemberLogCommand, ModMemberLog>();
            
        }
    }
}
