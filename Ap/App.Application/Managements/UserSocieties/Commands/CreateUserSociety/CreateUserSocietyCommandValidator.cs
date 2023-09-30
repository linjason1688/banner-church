#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserSocieties.Commands.CreateUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserSocietyCommandValidator 
        : AbstractValidator<CreateUserSocietyCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserSocietyCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserSociety, e => e.Name)
            //     );
        }
    }
}
