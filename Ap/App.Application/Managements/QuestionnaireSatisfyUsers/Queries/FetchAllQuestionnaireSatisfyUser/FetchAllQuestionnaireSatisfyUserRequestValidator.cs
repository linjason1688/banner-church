#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Queries.FetchAllQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllQuestionnaireSatisfyUserRequestValidator 
        : AbstractValidator<FetchAllQuestionnaireSatisfyUserRequest>
    {
        public FetchAllQuestionnaireSatisfyUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
