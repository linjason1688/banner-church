#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetUsers.Commands.CreateVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetUserCommandValidator 
        : AbstractValidator<CreateVwAspnetUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetUser, e => e.Name)
            //     );
        }
    }
}
