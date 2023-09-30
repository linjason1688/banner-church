#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.QuestionnaireDetails.Commands.CreateQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateQuestionnaireDetailCommandValidator 
        : AbstractValidator<CreateQuestionnaireDetailCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateQuestionnaireDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QuestionnaireDetail, e => e.Name)
            //     );
        }
    }
}
