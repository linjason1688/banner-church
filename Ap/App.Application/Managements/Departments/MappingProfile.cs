using AutoMapper;
using App.Application.Managements.Departments.ModDepartments.Commands.CreateModDepartment;
using App.Application.Managements.Departments.ModDepartments.Commands.UpdateModDepartment;
using App.Application.Managements.Departments.ModDepartments.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Departments.ModDepartments
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
            CreateMap<ModDepartment, ModDepartmentView>();
            
            CreateMap<CreateModDepartmentCommand, ModDepartment>();
            
            CreateMap<UpdateModDepartmentCommand, ModDepartment>();
            
        }
    }
}
