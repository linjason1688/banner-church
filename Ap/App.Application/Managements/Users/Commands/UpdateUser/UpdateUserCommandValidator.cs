#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Users.Commands.UpdateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserCommandValidator 
        : AbstractValidator<UpdateUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.User, e => e.Name)
            //     );
        }
    }
}
