#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Commands.CreateQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateQuestionnaireSatisfyUserCommandValidator 
        : AbstractValidator<CreateQuestionnaireSatisfyUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateQuestionnaireSatisfyUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QuestionnaireSatisfyUser, e => e.Name)
            //     );
        }
    }
}
