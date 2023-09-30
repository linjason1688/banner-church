using AutoMapper;
using App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.CreateModMemberClassTime;
using App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.UpdateModMemberClassTime;
using App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes
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
            CreateMap<ModMemberClassTime, ModMemberClassTimeView>();
            
            CreateMap<CreateModMemberClassTimeCommand, ModMemberClassTime>();
            
            CreateMap<UpdateModMemberClassTimeCommand, ModMemberClassTime>();
            
        }
    }
}
