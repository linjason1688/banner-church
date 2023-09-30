#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MessageInformations.Commands.CreateMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMessageInformationCommandValidator 
        : AbstractValidator<CreateMessageInformationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMessageInformationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MessageInformation, e => e.Name)
            //     );
        }
    }
}
