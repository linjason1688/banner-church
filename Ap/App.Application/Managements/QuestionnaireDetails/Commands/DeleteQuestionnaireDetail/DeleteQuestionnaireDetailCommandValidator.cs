#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Commands.DeleteQuestionnaireDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteQuestionnaireDetailCommandValidator 
        : AbstractValidator<DeleteQuestionnaireDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteQuestionnaireDetailCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
