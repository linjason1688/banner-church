#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Commands.UpdateQuestionnaireSatisfyUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateQuestionnaireSatisfyUserCommandValidator 
        : AbstractValidator<UpdateQuestionnaireSatisfyUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateQuestionnaireSatisfyUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QuestionnaireSatisfyUser, e => e.Name)
            //     );
        }
    }
}
