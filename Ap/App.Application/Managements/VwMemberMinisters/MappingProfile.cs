using AutoMapper;
using App.Application.Managements.VwMemberMinisters.Commands.CreateVwMemberMinister;
using App.Application.Managements.VwMemberMinisters.Commands.UpdateVwMemberMinister;
using App.Application.Managements.VwMemberMinisters.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwMemberMinisters
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
            CreateMap<VwMemberMinister, VwMemberMinisterView>();
            
            CreateMap<CreateVwMemberMinisterCommand, VwMemberMinister>();
            
            CreateMap<UpdateVwMemberMinisterCommand, VwMemberMinister>();
            
        }
    }
}
