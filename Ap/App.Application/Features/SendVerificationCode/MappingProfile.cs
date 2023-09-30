using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Features.SendVerificationCode
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
            this.CreateMap<SendVerificationCodeRequest, User>();
        }
    }
}
