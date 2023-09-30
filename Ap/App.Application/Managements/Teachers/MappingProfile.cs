using AutoMapper;
using App.Application.Managements.Teachers.Commands.CreateTeacher;
using App.Application.Managements.Teachers.Commands.UpdateTeacher;
using App.Application.Managements.Teachers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Teachers
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
            CreateMap<Teacher, TeacherView>();
            
            CreateMap<CreateTeacherCommand, Teacher>();
            
            CreateMap<UpdateTeacherCommand, Teacher>();
            
        }
    }
}
