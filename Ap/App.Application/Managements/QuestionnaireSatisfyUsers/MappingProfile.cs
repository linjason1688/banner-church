using AutoMapper;
using App.Application.Managements.QuestionnaireSatisfyUsers.Commands.CreateQuestionnaireSatisfyUser;
using App.Application.Managements.QuestionnaireSatisfyUsers.Commands.UpdateQuestionnaireSatisfyUser;
using App.Application.Managements.QuestionnaireSatisfyUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.QuestionnaireSatisfyUsers
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
            CreateMap<QuestionnaireSatisfyUser, QuestionnaireSatisfyUserView>();
            
            CreateMap<CreateQuestionnaireSatisfyUserCommand, QuestionnaireSatisfyUser>();
            
            CreateMap<UpdateQuestionnaireSatisfyUserCommand, QuestionnaireSatisfyUser>();
            
        }
    }
}
