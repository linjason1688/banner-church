using AutoMapper;
using App.Application.Managements.SysSettings.Commands.CreateSysSetting;
using App.Application.Managements.SysSettings.Commands.UpdateSysSetting;
using App.Application.Managements.SysSettings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysSettings
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
            CreateMap<SysSetting, SysSettingView>();
            
            CreateMap<CreateSysSettingCommand, SysSetting>();
            
            CreateMap<UpdateSysSettingCommand, SysSetting>();
            
        }
    }
}
