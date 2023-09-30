using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Features.UpdatePassword
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
            this.CreateMap<UpdatePasswordCommand, User>();
        }
    }
}
