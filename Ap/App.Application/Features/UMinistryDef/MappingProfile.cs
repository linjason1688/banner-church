using App.Domain.Entities.Features;
using AutoMapper;

//#CreateAPI
namespace App.Application.Features.UMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingUMinistryDef : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingUMinistryDef()
        {
            this.CreateMap<UMinistryDefCommand, MinistryDef>();
        }
    }
}
