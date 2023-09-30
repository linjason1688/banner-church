using AutoMapper;
using App.Application.Managements.Ministers.ModMinisters.Commands.CreateModMinister;
using App.Application.Managements.Ministers.ModMinisters.Commands.UpdateModMinister;
using App.Application.Managements.Ministers.ModMinisters.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Ministers.ModMinisters
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
            CreateMap<ModMinister, ModMinisterView>();
            
            CreateMap<CreateModMinisterCommand, ModMinister>();
            
            CreateMap<UpdateModMinisterCommand, ModMinister>();
            
        }
    }
}
