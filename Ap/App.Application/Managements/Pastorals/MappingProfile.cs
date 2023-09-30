using AutoMapper;
using App.Application.Managements.Pastorals.Commands.CreatePastoral;
using App.Application.Managements.Pastorals.Commands.UpdatePastoral;
using App.Application.Managements.Pastorals.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;
using App.Application.Managements.Pastorals.Queries.QueryPastoral;
using App.Application.Managements.Pastorals.Commands.DeletePastoral;

namespace App.Application.Managements.Pastorals
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
            CreateMap<Pastoral, PastoralView>();

            CreateMap<Pastoral, PastoralTreeView>();

            CreateMap<CreatePastoralCommand, Pastoral>();
            
            CreateMap<UpdatePastoralCommand, Pastoral>();

            CreateMap<UpdatePastoralCommand, PastoralView>();

            CreateMap<QueryPastoralRequest, PastoralView>();

            CreateMap<DeletePastoralCommand, PastoralView>();

        }
    }
}
