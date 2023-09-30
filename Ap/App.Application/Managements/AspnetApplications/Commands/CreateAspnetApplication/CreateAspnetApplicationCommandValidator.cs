#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetApplications.Commands.CreateAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetApplicationCommandValidator 
        : AbstractValidator<CreateAspnetApplicationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetApplicationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetApplication, e => e.Name)
            //     );
        }
    }
}
