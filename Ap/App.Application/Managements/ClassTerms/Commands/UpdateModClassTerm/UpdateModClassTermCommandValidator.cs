#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Commands.UpdateModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassTermCommandValidator 
        : AbstractValidator<UpdateModClassTermCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassTermCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassTerm, e => e.Name)
            //     );
        }
    }
}
