#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetApplications.Commands.CreateVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetApplicationCommandValidator 
        : AbstractValidator<CreateVwAspnetApplicationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetApplicationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetApplication, e => e.Name)
            //     );
        }
    }
}
