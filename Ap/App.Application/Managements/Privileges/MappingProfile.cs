using AutoMapper;
using App.Application.Managements.Privileges.Commands.CreatePrivilege;
using App.Application.Managements.Privileges.Commands.UpdatePrivilege;
using App.Application.Managements.Privileges.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Privileges
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
            CreateMap<Privilege, PrivilegeView>();

            CreateMap<CreatePrivilegeCommand, Privilege>();

            CreateMap<UpdatePrivilegeCommand, Privilege>();

            // 只針對特殊欄位 設定
            CreateMap<Privilege, PrivilegeNodeView>()
               .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
               .ForMember(d => d.Key, m => m.MapFrom(s => s.FunctionId.Trim().ToUpper()))
               .ForMember(d => d.ParentKey, m => m.MapFrom(s => s.ParentFunctionId.Trim().ToUpper()));
        }
    }
}
