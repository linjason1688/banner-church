#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Commands.DeleteQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteQuestionnaireSatisfyUserCommandValidator 
        : AbstractValidator<DeleteQuestionnaireSatisfyUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteQuestionnaireSatisfyUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
