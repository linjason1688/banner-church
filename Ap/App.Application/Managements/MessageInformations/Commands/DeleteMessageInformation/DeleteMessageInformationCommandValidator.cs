#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Commands.DeleteMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMessageInformationCommandValidator 
        : AbstractValidator<DeleteMessageInformationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMessageInformationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
