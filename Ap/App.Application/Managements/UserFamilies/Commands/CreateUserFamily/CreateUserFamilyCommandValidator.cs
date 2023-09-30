#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserFamilies.Commands.CreateUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserFamilyCommandValidator 
        : AbstractValidator<CreateUserFamilyCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserFamilyCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserFamily, e => e.Name)
            //     );
        }
    }
}
