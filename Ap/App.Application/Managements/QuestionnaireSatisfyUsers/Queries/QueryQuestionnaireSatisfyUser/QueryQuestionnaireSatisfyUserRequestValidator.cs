#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Queries.QueryQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryQuestionnaireSatisfyUserRequestValidator 
        : AbstractValidator<QueryQuestionnaireSatisfyUserRequest>
    {
        public QueryQuestionnaireSatisfyUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
