using AutoMapper;
using App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.CreateModMemberClassDay;
using App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.UpdateModMemberClassDay;
using App.Application.Managements.MemberClassDays.ModMemberClassDays.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays
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
            CreateMap<ModMemberClassDay, ModMemberClassDayView>();
            
            CreateMap<CreateModMemberClassDayCommand, ModMemberClassDay>();
            
            CreateMap<UpdateModMemberClassDayCommand, ModMemberClassDay>();
            
        }
    }
}
