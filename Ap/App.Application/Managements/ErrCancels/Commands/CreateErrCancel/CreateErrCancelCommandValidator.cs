#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ErrCancels.Commands.CreateErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateErrCancelCommandValidator 
        : AbstractValidator<CreateErrCancelCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateErrCancelCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ErrCancel, e => e.Name)
            //     );
        }
    }
}
