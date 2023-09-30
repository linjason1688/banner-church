using AutoMapper;
using App.Application.Managements.Depts.Commands.CreateDept;
using App.Application.Managements.Depts.Commands.UpdateDept;
using App.Application.Managements.Depts.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;
using App.Application.Managements.Depts.Queries.QueryDept;
using App.Application.Managements.Depts.Commands.DeleteDept;

namespace App.Application.Managements.Depts
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
            CreateMap<Dept, DeptView>();
            
            CreateMap<CreateDeptCommand, Dept>();
            
            CreateMap<UpdateDeptCommand, Dept>();

            CreateMap<UpdateDeptCommand, DeptView>();

            CreateMap<QueryDeptRequest, DeptView>();

            CreateMap<DeleteDeptCommand, DeptView>();


        }
    }
}
