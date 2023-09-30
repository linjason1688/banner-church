#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetUsers.Commands.CreateAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetUserCommandValidator 
        : AbstractValidator<CreateAspnetUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetUser, e => e.Name)
            //     );
        }
    }
}
