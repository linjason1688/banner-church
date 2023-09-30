#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserExpertises.Commands.UpdateUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserExpertiseCommandValidator 
        : AbstractValidator<UpdateUserExpertiseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserExpertiseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserExpertise, e => e.Name)
            //     );
        }
    }
}
