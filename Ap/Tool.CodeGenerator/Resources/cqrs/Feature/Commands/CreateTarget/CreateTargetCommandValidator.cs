#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.$BaseNamespace$$Feature$.Commands.Create$Target$
{
    /// <summary>
    /// 
    /// </summary>
    public class Create$Target$CommandValidator 
        : AbstractValidator<Create$Target$Command>
    {
        /// <summary>
        /// 
        /// </summary>
        public Create$Target$CommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.$Target$, e => e.Name)
            //     );
        }
    }
}
