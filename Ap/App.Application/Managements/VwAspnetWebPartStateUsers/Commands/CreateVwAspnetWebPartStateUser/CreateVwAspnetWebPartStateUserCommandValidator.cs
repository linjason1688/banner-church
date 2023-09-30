#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Commands.CreateVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStateUserCommandValidator 
        : AbstractValidator<CreateVwAspnetWebPartStateUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStateUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStateUser, e => e.Name)
            //     );
        }
    }
}
