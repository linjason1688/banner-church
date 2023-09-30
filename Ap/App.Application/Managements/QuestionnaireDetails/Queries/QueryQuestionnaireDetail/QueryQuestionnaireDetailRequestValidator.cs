#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Queries.QueryQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryQuestionnaireDetailRequestValidator 
        : AbstractValidator<QueryQuestionnaireDetailRequest>
    {
        public QueryQuestionnaireDetailRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
