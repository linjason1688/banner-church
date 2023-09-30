#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ErrCancels.Commands.UpdateErrCancel
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateErrCancelCommandValidator 
        : AbstractValidator<UpdateErrCancelCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateErrCancelCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ErrCancel, e => e.Name)
            //     );
        }
    }
}
