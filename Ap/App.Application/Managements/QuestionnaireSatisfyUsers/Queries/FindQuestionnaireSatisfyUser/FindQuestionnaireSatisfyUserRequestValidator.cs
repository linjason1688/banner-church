#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Queries.FindQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindQuestionnaireSatisfyUserRequestValidator 
        : AbstractValidator<FindQuestionnaireSatisfyUserRequest>
    {
        public FindQuestionnaireSatisfyUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
