#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.CreateModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModRollcallWorkCommandValidator 
        : AbstractValidator<CreateModRollcallWorkCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModRollcallWorkCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModRollcallWork, e => e.Name)
            //     );
        }
    }
}
