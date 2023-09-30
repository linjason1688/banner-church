#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Questionnaires.Queries.QueryQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryQuestionnaireRequestValidator 
        : AbstractValidator<QueryQuestionnaireRequest>
    {
        public QueryQuestionnaireRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
