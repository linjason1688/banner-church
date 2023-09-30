#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Commands.CreateModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModRollcallCommandValidator 
        : AbstractValidator<CreateModRollcallCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModRollcallCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModRollcall, e => e.Name)
            //     );
        }
    }
}
