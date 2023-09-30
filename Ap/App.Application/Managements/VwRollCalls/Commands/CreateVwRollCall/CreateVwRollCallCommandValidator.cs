#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwRollCalls.Commands.CreateVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwRollCallCommandValidator 
        : AbstractValidator<CreateVwRollCallCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwRollCallCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwRollCall, e => e.Name)
            //     );
        }
    }
}
