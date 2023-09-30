using AutoMapper;
using App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.CreateModMemberClassDayTerm;
using App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.UpdateModMemberClassDayTerm;
using App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms
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
            CreateMap<ModMemberClassDayTerm, ModMemberClassDayTermView>();
            
            CreateMap<CreateModMemberClassDayTermCommand, ModMemberClassDayTerm>();
            
            CreateMap<UpdateModMemberClassDayTermCommand, ModMemberClassDayTerm>();
            
        }
    }
}
