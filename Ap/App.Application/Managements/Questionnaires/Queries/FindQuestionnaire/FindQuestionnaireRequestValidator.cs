#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Questionnaires.Queries.FindQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class FindQuestionnaireRequestValidator 
        : AbstractValidator<FindQuestionnaireRequest>
    {
        public FindQuestionnaireRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
