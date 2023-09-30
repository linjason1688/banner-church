#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Commands.UpdateQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateQuestionnaireDetailCommandValidator 
        : AbstractValidator<UpdateQuestionnaireDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateQuestionnaireDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.QuestionnaireDetail, e => e.Name)
            //     );
        }
    }
}
