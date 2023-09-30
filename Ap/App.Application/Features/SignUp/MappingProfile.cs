using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Features.SignUp
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
            this.CreateMap<SignUpCommand, User>();
        }
    }
}
