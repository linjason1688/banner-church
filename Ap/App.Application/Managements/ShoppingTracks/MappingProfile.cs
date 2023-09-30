using AutoMapper;
using App.Application.Managements.ShoppingTracks.Commands.CreateShoppingTrack;
using App.Application.Managements.ShoppingTracks.Commands.UpdateShoppingTrack;
using App.Application.Managements.ShoppingTracks.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ShoppingTracks
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
            CreateMap<ShoppingTrack, ShoppingTrackView>();
            
            CreateMap<CreateShoppingTrackCommand, ShoppingTrack>();
            
            CreateMap<UpdateShoppingTrackCommand, ShoppingTrack>();
            
        }
    }
}
