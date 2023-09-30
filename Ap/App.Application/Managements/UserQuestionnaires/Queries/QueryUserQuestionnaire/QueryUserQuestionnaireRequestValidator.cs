#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Queries.QueryUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserQuestionnaireRequestValidator 
        : AbstractValidator<QueryUserQuestionnaireRequest>
    {
        public QueryUserQuestionnaireRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
