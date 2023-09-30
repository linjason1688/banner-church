#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserExpertises.Commands.CreateUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserExpertiseCommandValidator 
        : AbstractValidator<CreateUserExpertiseCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserExpertiseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserExpertise, e => e.Name)
            //     );
        }
    }
}
