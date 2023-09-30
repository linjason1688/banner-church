#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Questionnaires.Queries.FetchAllQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllQuestionnaireRequestValidator 
        : AbstractValidator<FetchAllQuestionnaireRequest>
    {
        public FetchAllQuestionnaireRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
