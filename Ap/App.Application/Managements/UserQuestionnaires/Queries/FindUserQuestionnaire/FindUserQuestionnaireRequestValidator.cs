#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Queries.FindUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserQuestionnaireRequestValidator 
        : AbstractValidator<FindUserQuestionnaireRequest>
    {
        public FindUserQuestionnaireRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
