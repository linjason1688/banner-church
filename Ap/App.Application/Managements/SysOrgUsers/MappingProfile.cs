using AutoMapper;
using App.Application.Managements.SysOrgUsers.Commands.CreateSysOrgUser;
using App.Application.Managements.SysOrgUsers.Commands.UpdateSysOrgUser;
using App.Application.Managements.SysOrgUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysOrgUsers
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
            CreateMap<SysOrgUser, SysOrgUserView>();
            
            CreateMap<CreateSysOrgUserCommand, SysOrgUser>();
            
            CreateMap<UpdateSysOrgUserCommand, SysOrgUser>();
            
        }
    }
}
