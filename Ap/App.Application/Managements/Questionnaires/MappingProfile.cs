using AutoMapper;
using App.Application.Managements.Questionnaires.Commands.CreateQuestionnaire;
using App.Application.Managements.Questionnaires.Commands.UpdateQuestionnaire;
using App.Application.Managements.Questionnaires.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Questionnaires
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
            CreateMap<Questionnaire, QuestionnaireView>();
            
            CreateMap<CreateQuestionnaireCommand, Questionnaire>();
            
            CreateMap<UpdateQuestionnaireCommand, Questionnaire>();
            
        }
    }
}
