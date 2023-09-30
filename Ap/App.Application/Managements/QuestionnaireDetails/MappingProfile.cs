using AutoMapper;
using App.Application.Managements.QuestionnaireDetails.Commands.CreateQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Commands.UpdateQuestionnaireDetail;
using App.Application.Managements.QuestionnaireDetails.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.QuestionnaireDetails
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
            CreateMap<QuestionnaireDetail, QuestionnaireDetailView>();
            
            CreateMap<CreateQuestionnaireDetailCommand, QuestionnaireDetail>();
            
            CreateMap<UpdateQuestionnaireDetailCommand, QuestionnaireDetail>();

            CreateMap<QuestionnaireDetailView, QuestionnaireDetail>();

        }
    }
}
