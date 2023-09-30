using AutoMapper;
using App.Application.Managements.QrCodes.Commands.CreateQrCode;
using App.Application.Managements.QrCodes.Commands.UpdateQrCode;
using App.Application.Managements.QrCodes.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.QrCodes
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
            CreateMap<QrCode, QrCodeView>();
            
            CreateMap<CreateQrCodeCommand, QrCode>();
            
            CreateMap<UpdateQrCodeCommand, QrCode>();

            CreateMap<QrCodeView, UpdateQrCodeCommand>();

        }
    }
}
