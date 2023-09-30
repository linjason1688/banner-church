#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Commands.Update$Target$
{
    /// <summary>
    /// 
    /// </summary>
    public class Update$Target$CommandValidator 
        : AbstractValidator<Update$Target$Command>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public Update$Target$CommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.$Target$, e => e.Name)
            //     );
        }
    }
}
