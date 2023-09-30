#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Queries.FetchAllUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserQuestionnaireRequestValidator 
        : AbstractValidator<FetchAllUserQuestionnaireRequest>
    {
        public FetchAllUserQuestionnaireRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
