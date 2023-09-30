#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Questionnaires.Commands.UpdateQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateQuestionnaireCommandValidator 
        : AbstractValidator<UpdateQuestionnaireCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateQuestionnaireCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Questionnaire, e => e.Name)
            //     );
        }
    }
}
