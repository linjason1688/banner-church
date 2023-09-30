using AutoMapper;
using App.Application.$BaseNamespace$$Feature$.Commands.Create$Target$;
using App.Application.$BaseNamespace$$Feature$.Commands.Update$Target$;
using App.Application.$BaseNamespace$$Feature$.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.$BaseNamespace$$Feature$
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
            CreateMap<$Target$, $Target$View>();
            
            CreateMap<Create$Target$Command, $Target$>();
            
            CreateMap<Update$Target$Command, $Target$>();
            
        }
    }
}
