#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Queries.FetchAllQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllQuestionnaireDetailRequestValidator 
        : AbstractValidator<FetchAllQuestionnaireDetailRequest>
    {
        public FetchAllQuestionnaireDetailRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
