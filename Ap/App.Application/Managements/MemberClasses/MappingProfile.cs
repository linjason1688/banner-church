using AutoMapper;
using App.Application.Managements.MemberClasses.ModMemberClasses.Commands.CreateModMemberClass;
using App.Application.Managements.MemberClasses.ModMemberClasses.Commands.UpdateModMemberClass;
using App.Application.Managements.MemberClasses.ModMemberClasses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberClasses.ModMemberClasses
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
            CreateMap<ModMemberClass, ModMemberClassView>();
            
            CreateMap<CreateModMemberClassCommand, ModMemberClass>();
            
            CreateMap<UpdateModMemberClassCommand, ModMemberClass>();
            
        }
    }
}
