using AutoMapper;
using App.Application.Managements.UserQuestionnaires.Commands.CreateUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Commands.UpdateUserQuestionnaire;
using App.Application.Managements.UserQuestionnaires.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserQuestionnaires
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
            CreateMap<UserQuestionnaire, UserQuestionnaireView>();
            
            CreateMap<CreateUserQuestionnaireCommand, UserQuestionnaire>();
            
            CreateMap<UpdateUserQuestionnaireCommand, UserQuestionnaire>();
            
        }
    }
}
