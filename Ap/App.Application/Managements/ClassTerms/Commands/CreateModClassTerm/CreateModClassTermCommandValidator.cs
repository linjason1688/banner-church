#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Commands.CreateModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassTermCommandValidator 
        : AbstractValidator<CreateModClassTermCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModClassTermCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassTerm, e => e.Name)
            //     );
        }
    }
}
