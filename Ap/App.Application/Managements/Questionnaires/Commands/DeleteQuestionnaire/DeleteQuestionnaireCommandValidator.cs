#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Questionnaires.Commands.DeleteQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteQuestionnaireCommandValidator 
        : AbstractValidator<DeleteQuestionnaireCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteQuestionnaireCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
