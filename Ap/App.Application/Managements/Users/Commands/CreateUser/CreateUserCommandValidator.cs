#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Users.Commands.CreateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserCommandValidator 
        : AbstractValidator<CreateUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.User, e => e.Name)
            //     );
        }
    }
}
