#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Queries.FindQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FindQuestionnaireDetailRequestValidator 
        : AbstractValidator<FindQuestionnaireDetailRequest>
    {
        public FindQuestionnaireDetailRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
