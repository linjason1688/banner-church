using System;
using App.Application.Managements.Questionnaires.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserQuestionnaires.Dtos
{
    /// <summary>
    /// UserQuestionnaire 
    /// </summary>
    public class UserQuestionnaireView : UserQuestionnaireBase, IEntityBase
    {



        /// <summary>
        /// Questionnaire
        /// </summary>
        public QuestionnaireView Questionnaire { get; set; } = new();


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

    }
}
