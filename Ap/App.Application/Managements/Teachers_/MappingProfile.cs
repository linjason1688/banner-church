using AutoMapper;
using App.Application.Managements.Teachers.ModTeachers.Commands.CreateModTeacher;
using App.Application.Managements.Teachers.ModTeachers.Commands.UpdateModTeacher;
using App.Application.Managements.Teachers.ModTeachers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Teachers.ModTeachers
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
            CreateMap<ModTeacher, ModTeacherView>();
            
            CreateMap<CreateModTeacherCommand, ModTeacher>();
            
            CreateMap<UpdateModTeacherCommand, ModTeacher>();
            
        }
    }
}
