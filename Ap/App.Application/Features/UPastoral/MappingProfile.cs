using App.Domain.Entities.Features;
using AutoMapper;

//#CreateAPI
namespace App.Application.Features.UPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingUPastoral : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingUPastoral()
        {
            this.CreateMap<UPastoralCommand, Pastoral>();
        }
    }
}
