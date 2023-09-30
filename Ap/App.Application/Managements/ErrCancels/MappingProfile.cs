using AutoMapper;
using App.Application.Managements.ErrCancels.Commands.CreateErrCancel;
using App.Application.Managements.ErrCancels.Commands.UpdateErrCancel;
using App.Application.Managements.ErrCancels.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ErrCancels
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
            CreateMap<ErrCancel, ErrCancelView>();
            
            CreateMap<CreateErrCancelCommand, ErrCancel>();
            
            CreateMap<UpdateErrCancelCommand, ErrCancel>();
            
        }
    }
}
