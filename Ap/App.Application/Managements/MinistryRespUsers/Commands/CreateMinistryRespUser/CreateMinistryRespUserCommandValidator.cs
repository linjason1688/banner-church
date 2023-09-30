#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryRespUsers.Commands.CreateMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryRespUserCommandValidator 
        : AbstractValidator<CreateMinistryRespUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryRespUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryRespUser, e => e.Name)
            //     );
        }
    }
}
