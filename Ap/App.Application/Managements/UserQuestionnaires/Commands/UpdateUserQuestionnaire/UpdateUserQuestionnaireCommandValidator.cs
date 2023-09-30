#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Commands.UpdateUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserQuestionnaireCommandValidator 
        : AbstractValidator<UpdateUserQuestionnaireCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserQuestionnaireCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserQuestionnaire, e => e.Name)
            //     );
        }
    }
}
