#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Commands.UpdateMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMessageInformationCommandValidator 
        : AbstractValidator<UpdateMessageInformationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMessageInformationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MessageInformation, e => e.Name)
            //     );
        }
    }
}
