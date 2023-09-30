#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserQuestionnaires.Commands.CreateUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserQuestionnaireCommandValidator 
        : AbstractValidator<CreateUserQuestionnaireCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserQuestionnaireCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserQuestionnaire, e => e.Name)
            //     );
        }
    }
}
