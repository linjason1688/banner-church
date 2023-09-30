#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Commands.DeleteUserQuestionnaire
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserQuestionnaireCommandValidator 
        : AbstractValidator<DeleteUserQuestionnaireCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserQuestionnaireCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
