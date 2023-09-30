using AutoMapper;
using App.Application.Managements.ClassDays.ModClassDays.Commands.CreateModClassDay;
using App.Application.Managements.ClassDays.ModClassDays.Commands.UpdateModClassDay;
using App.Application.Managements.ClassDays.ModClassDays.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ClassDays.ModClassDays
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
            CreateMap<ModClassDay, ModClassDayView>();
            
            CreateMap<CreateModClassDayCommand, ModClassDay>();
            
            CreateMap<UpdateModClassDayCommand, ModClassDay>();
            
        }
    }
}
