#region

using App.Application.Core.Logs.Dtos;
using App.Domain.Entities.Core;
using AutoMapper;

#endregion

namespace App.Application.Core.Logs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApiAuditLog, ApiAuditLogView>()
               .ReverseMap();

            this.CreateMap<ExceptionLog, ExceptionLogView>()
               .ReverseMap();
        }
    }
}
