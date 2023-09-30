#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Questionnaires.Commands.CreateQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateQuestionnaireCommandValidator 
        : AbstractValidator<CreateQuestionnaireCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateQuestionnaireCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Questionnaire, e => e.Name)
            //     );
        }
    }
}
